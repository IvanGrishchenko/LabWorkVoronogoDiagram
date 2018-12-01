using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrew_Jarvis : MonoBehaviour {
    public Color lineColor;
    public float lineScale;
    LogicManager logicManager;
    List<Line> lines = new List<Line>();
	void Start () {
        logicManager = LogicManager.ins;
        logicManager.CreateArray();
        
        CreateLineBetweenMostDots();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void FindLeftAndRightMostDots(out DotObject leftMost, out DotObject rightMost)
    {
        DotObject[] dotObjectsArray = logicManager.dotObjectsArray;
        leftMost = dotObjectsArray[0];
        rightMost = dotObjectsArray[0];


        foreach (DotObject dotGO in dotObjectsArray)
        {
            if (dotGO.dot.x < leftMost.dot.x)
                leftMost = dotGO;
            else if (dotGO.dot.x > rightMost.dot.x)
                rightMost = dotGO;
        }
    }
    void CreateLineBetweenMostDots()
    {
        DotObject leftMost,  rightMost;
        FindLeftAndRightMostDots(out leftMost,out  rightMost);
        lines.Add(CreateLine(leftMost,rightMost));
        
    }
    Line CreateLine(DotObject dot1, DotObject dot2)
    {
        Line line = new Line(dot1.dot, dot2.dot);
        line.lineGameObject.transform.localScale = line.lineGameObject.transform.localScale.Multiply(new Vector3(lineScale,lineScale,1));
        line.lineGameObject.GetComponent<Renderer>().material.color = lineColor;
        return line;
    }
    
}
