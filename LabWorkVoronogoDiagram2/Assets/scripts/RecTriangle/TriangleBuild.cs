using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBuild : MonoBehaviour
{
    public Color lineColor;
    public float lineScale;

    LogicManager logicManager;
    List<Line> lines = new List<Line>();

    List<Dot> TrianglesVertexes1 = new List<Dot>();
    List<Dot> TrianglesVertexes2 = new List<Dot>();
    List<DotObject> list1 = new List<DotObject>();
    List<DotObject> list2 = new List<DotObject>();

    public enum MirrorPosition { Same, Opposite }

    public void Triagle(Line Foundation,Dot other, MirrorPosition type, List<DotObject> list, List<Dot> TriangleVertexes)
    {
        int otherValueinLine = DivideInto2ArraysByLine.CompareByLine(Foundation, other);
        if (otherValueinLine == 0)
            Debug.LogError("Point is on the foundation");
        if (type == MirrorPosition.Opposite)
            otherValueinLine *= -1;
        Line Side1 = null;
        Line Side2 = null;
        float MaxArea = -1f;
        foreach(DotObject dotGO in list)
        {
            if( DivideInto2ArraysByLine.CompareByLine(Foundation, dotGO.dot)*otherValueinLine > 0 )
                SquareCalc.calculatedArea(Foundation, dotGO.dot, ref MaxArea, 0f, ref Side1, ref Side2);
        }
    }

    void IStart()
    {
        float wait = 0.1f;
        logicManager = LogicManager.ins;
        logicManager.CreateArray();
        DotObject[] dotObjectsArray = logicManager.dotObjectsArray;
        CreateLineBetweenMostDots();
        DivideInto2ArraysByLine.Divide(lines[0], dotObjectsArray, out list1, out list2);
        list1.SetColor(Color.yellow);
        list2.SetColor(Color.cyan);

        Triagle(lines[0], list1[0].dot, MirrorPosition.Opposite, list2, TrianglesVertexes1);

    }

    private void Start()
    {
        IStart();
    }





    void FindLeftAndRightMostDots(out DotObject leftMost, out DotObject rightMost)
    {
        DotObject[] dotObjectsArray = logicManager.dotObjectsArray;
        leftMost = dotObjectsArray[0];
        rightMost = dotObjectsArray[dotObjectsArray.Length - 1];
    }
    void CreateLineBetweenMostDots()
    {
        DotObject leftMost, rightMost;
        DotObject[] dotObjectsArray = logicManager.dotObjectsArray;
        System.Array.Sort(dotObjectsArray);
        FindLeftAndRightMostDots(out leftMost, out rightMost);
        lines.Add(CreateLine(leftMost, rightMost));

    }
    Line CreateLine(DotObject dot1, DotObject dot2)
    {
        Line line = new Line(dot1.dot, dot2.dot);
        line.lineGameObject.transform.localScale = line.lineGameObject.transform.localScale.Multiply(new Vector3(lineScale, lineScale, 1));
        line.lineGameObject.GetComponent<Renderer>().material.color = lineColor;
        return line;
    }
}    