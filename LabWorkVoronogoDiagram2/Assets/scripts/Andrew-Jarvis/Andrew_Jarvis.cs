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
        rightMost = dotObjectsArray[dotObjectsArray.Length - 1];
    }
    void CreateLineBetweenMostDots()
    {
        DotObject leftMost,  rightMost;
        DotObject[] dotObjectsArray = logicManager.dotObjectsArray;
        System.Array.Sort(dotObjectsArray);
        FindLeftAndRightMostDots(out  leftMost, out  rightMost);
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
