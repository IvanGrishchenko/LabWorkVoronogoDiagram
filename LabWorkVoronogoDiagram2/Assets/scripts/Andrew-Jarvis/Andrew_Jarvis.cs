using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andrew_Jarvis : MonoBehaviour {
    public Color lineColor;
    public float lineScale;
    LogicManager logicManager;
    List<Line> lines = new List<Line>();
    List<DotObject> list1 = new List<DotObject>();
    List<DotObject> list2 = new List<DotObject>();
    private void Start()
    {
        StartCoroutine(IStart());
    }
    int j = 0;
    IEnumerator IStart () {
        float wait = 0.1f;
        logicManager = LogicManager.ins;
        logicManager.CreateArray();
        DotObject[] dotObjectsArray = logicManager.dotObjectsArray;
        CreateLineBetweenMostDots();
        DivideInto2ArraysByLine.Divide(lines[0], dotObjectsArray,out list1,out list2);
        list1.SetColor(Color.yellow);
        list2.SetColor(Color.cyan);
        
        Line line = null;

        Dot startDot = lines[0].dot1.Copy() ;
        Dot other = lines[0].dot2;
        bool success = true;
        int c = 0;
        int jcopy;
        
        List<Dot> dotsCopy = new List<Dot>();
        dotsCopy.Add(dotObjectsArray[0].dot.Copy());
        list1.Add(dotObjectsArray[dotObjectsArray.Length - 1]);
        foreach (DotObject dob in list1)
        {
            dotsCopy.Add(dob.dot.Copy());
        }
        
        list1.Add(dotObjectsArray[0]);
        while (success )
        {

            int i = 0;
            for(;i < dotsCopy.Count; i++)
            {
                if (dotsCopy[i].x >= startDot.x)
                    break;
            }
            success = false;
            
            Dot startDotCopy = startDot.Copy();
            while (dotsCopy.Count > 0 && i < dotsCopy.Count && !DivideInto2ArraysByLine.TryDivide(ref startDot,other ,dotsCopy[i], list1, out line, wait))
            {
                yield return new WaitForSeconds(wait);
                i++;
            }
               
            
            if (startDot != startDotCopy && line !=null)
            {
                yield return new WaitForSeconds(wait);
               
                if (startDot == dotObjectsArray[dotObjectsArray.Length - 1].dot)
                {
                    success = false;
                    
                    break;
                }


                jcopy = j;
                    dotsCopy.RemoveAt(j);
                if (i < j)
                    j = i;
                else
                    j = i - 1;



                success = true;
            }
            
           
        }








       
       
     
     
       
      

        line = null;

         startDot = lines[0].dot1.Copy();
         other = lines[0].dot2;
         success = true;

        j = 0;

         dotsCopy = new List<Dot>();
        dotsCopy.Add(dotObjectsArray[0].dot.Copy());
        list2.Add(dotObjectsArray[dotObjectsArray.Length - 1]);
        foreach (DotObject dob in list2)
        {
            dotsCopy.Add(dob.dot.Copy());
        }

        list2.Add(dotObjectsArray[0]);
        while (success)
        {


            int i = 0;
            for (; i < dotsCopy.Count; i++)
            {
                if (dotsCopy[i].x >= startDot.x)
                    break;
            }
            success = false;

            Dot startDotCopy = startDot.Copy();
            while (dotsCopy.Count > 0 && i < dotsCopy.Count && !DivideInto2ArraysByLine.TryDivide(ref startDot, other, dotsCopy[i], list2, out line,wait))
            {
                i++;
            }
               

            if (startDot != startDotCopy && line != null)
            {
                yield return new WaitForSeconds(wait);

                if (startDot == dotObjectsArray[dotObjectsArray.Length - 1].dot)
                {
                    success = false;
                    
                    break;
                }


                jcopy = j;
                dotsCopy.RemoveAt(j);
                if (i < j)
                    j = i;
                else
                    j = i - 1;



                success = true;
            }


        }
        

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
