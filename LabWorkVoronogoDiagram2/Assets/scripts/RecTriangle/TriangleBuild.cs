using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleBuild : MonoBehaviour
{
    public Color lineColor;
    public float lineScale;

    bool isRunning = false;

    static int StackCount = 0;

    LogicManager logicManager;
    List<Line> lines = new List<Line>();

    List<Dot> TrianglesVertexes1 = new List<Dot>();
    List<Dot> TrianglesVertexes2 = new List<Dot>();
    List<DotObject> list1 = new List<DotObject>();
    List<DotObject> list2 = new List<DotObject>();

    public enum MirrorPosition { Same, Opposite }

    public IEnumerator Triagle(Line Foundation,Dot other, MirrorPosition type, List<Dot> list, List<Dot> TriangleVertexes)
    {
        StackCount++;
        float waitTime = 0.02f;
        WaitForSeconds wait = new WaitForSeconds(waitTime);
        int otherValueinLine = DivideInto2ArraysByLine.CompareByLine(Foundation, other);
        if (otherValueinLine == 0)
            Debug.LogError("Point is on the foundation");
        if (type == MirrorPosition.Opposite)
            otherValueinLine *= -1;
        Line Side1 = null;
        Line Side2 = null;
        float MaxArea = -1f;
        foreach(Dot dot in list)
        {
            if (DivideInto2ArraysByLine.CompareByLine(Foundation, dot) * otherValueinLine > 0 )
            {
                if (SquareCalc.calculatedArea(Foundation, dot, ref MaxArea, waitTime * 0.75f, ref Side1, ref Side2) == MaxArea) ;
                yield return wait;
            }
        }
        List<Dot> subset1, subset2;
        if (Side1 != null)
        {
            TriangleVertexes.Add(Side1.dot2.Copy());
            DivideInto2ArraysByLine.DivideByDotAndLine(Side1, Foundation.dot2.Copy(), MirrorPosition.Opposite, list, out subset1);
            if (subset1.Count > 0)
            {
                StartCoroutine(Triagle(Side1, Foundation.dot2.Copy(), MirrorPosition.Opposite, list, TriangleVertexes));
            }
        }
        if (Side2 != null)
        {
            
            DivideInto2ArraysByLine.DivideByDotAndLine(Side2, Foundation.dot1.Copy(), MirrorPosition.Opposite, list, out subset2);
            if (subset2.Count > 0)
            {
                StartCoroutine(Triagle(Side2, Foundation.dot1.Copy(), MirrorPosition.Opposite, list, TriangleVertexes));
            }
        }
        StackCount--;
        if (StackCount == 0)
            isRunning = false;
    }

    void BuildLinesByDotArray(Dot[] dotlist, out List<Line> OuterLines)
    {
        OuterLines = new List<Line>();
        for(int i=0; i < dotlist.Length - 1; ++i)
        {
            OuterLines.Add(new Line(dotlist[i].Copy(), dotlist[i + 1].Copy(), Color.green,1.1f));
        }
    }

    List<Dot> ReturnDotList(List<DotObject> dotObjectsList)
    {
        List<Dot> dotlist = new List<Dot>();
        foreach (DotObject dotGO in dotObjectsList)
        {
            dotlist.Add(dotGO.dot.Copy());
        }
        return dotlist;
    }
    
    IEnumerator WaitingtoProceed()
    {
        while (isRunning)
            yield return null;
        
        List<Dot> dotlist1 = ReturnDotList(list1);
        if (list2.Count > 0)
        {
            StartCoroutine(Triagle(lines[0], list2[0].dot, MirrorPosition.Opposite, dotlist1, TrianglesVertexes1));
            isRunning = true;
        }
        else if (list1.Count > 0)
        {
            StartCoroutine(Triagle(lines[0], list1[0].dot, MirrorPosition.Same, dotlist1, TrianglesVertexes1));
            isRunning = true;
        }
        while (isRunning)
            yield return null;
        List<Line> List1;
        List<Line> List2;
        TrianglesVertexes1.Add(lines[0].dot1.Copy());
        TrianglesVertexes1.Add(lines[0].dot2.Copy());
        TrianglesVertexes2.Add(lines[0].dot1.Copy());
        TrianglesVertexes2.Add(lines[0].dot2.Copy());
        Dot[] array1 = TrianglesVertexes1.ToArray();
        Dot[] array2 = TrianglesVertexes2.ToArray();
        System.Array.Sort(array1);
        System.Array.Sort(array2);
        
        BuildLinesByDotArray(array1, out List1);
        BuildLinesByDotArray(array2, out List2);

    }

    void IStart()
    {
        
        logicManager = LogicManager.ins;
        logicManager.CreateArray();
        DotObject[] dotObjectsArray = logicManager.dotObjectsArray;
        CreateLineBetweenMostDots();
        DivideInto2ArraysByLine.Divide(lines[0], dotObjectsArray, out list1, out list2);
        list1.SetColor(Color.yellow);
        list2.SetColor(Color.cyan);

        
        List<Dot> dotlist2 = ReturnDotList(list2);
        if (list1.Count > 0)
        {
            StartCoroutine(Triagle(lines[0], list1[0].dot, MirrorPosition.Opposite, dotlist2, TrianglesVertexes2));
            isRunning = true;
        }
        else if (list2.Count > 0)
        {
            StartCoroutine(Triagle(lines[0], list2[0].dot, MirrorPosition.Same, dotlist2, TrianglesVertexes2));
            isRunning = true;
        }
       
        StartCoroutine(WaitingtoProceed());

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