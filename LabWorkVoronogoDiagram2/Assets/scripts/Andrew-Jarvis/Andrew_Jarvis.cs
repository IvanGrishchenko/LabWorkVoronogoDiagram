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
        
<<<<<<< HEAD
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
               
            
            if (startDot.compare(startDotCopy) && line !=null)
            {
                yield return new WaitForSeconds(0.2f);
               
               


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
                i++;

            if (startDot.compare(startDotCopy) && line != null)
            {
                yield return new WaitForSeconds(0.2f);

                


                jcopy = j;
                dotsCopy.RemoveAt(j);
                if (i < j)
                    j = i;
                else
                    j = i - 1;



                success = true;
            }


        }
        Debug.LogError("endddddddddddddd");
=======
        CreateLineBetweenMostDots();
>>>>>>> parent of 001ed33... Готов метод Эндрю-Джарвиса

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
