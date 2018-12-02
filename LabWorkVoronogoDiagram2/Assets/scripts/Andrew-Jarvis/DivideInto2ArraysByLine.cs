using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DivideInto2ArraysByLine {


    public static void Divide(Line line, DotObject[] dots, out List<DotObject> list1, out List<DotObject> list2)
    {
        list1 = new List<DotObject>(); list2 = new List<DotObject>();
        int resOfComparison;
        foreach (DotObject dotGO in dots)
        {
            resOfComparison = CompareByLine(line, dotGO.dot);
            if (resOfComparison == 0)
                continue;
            else if (resOfComparison < 0)
            {
                list1.Add(dotGO);
            }
            else
            {
                list2.Add(dotGO);
            }
        }
    }

    public static void DivideByDotAndLine(Line line, Dot otherdot, TriangleBuild.MirrorPosition type, List<Dot> dotlist, out List<Dot> outdots)
    {
        outdots = new List<Dot>();
        int resOfComparison;
        int otherValueinLine = CompareByLine(line, otherdot);
        if (otherValueinLine == 0)
            Debug.LogError("Point is on the foundation");
        if (type == TriangleBuild.MirrorPosition.Opposite)
            otherValueinLine *= -1;
        foreach (Dot dot in dotlist)
        {
            if (CompareByLine(line, dot) * otherValueinLine > 0)
            {
                outdots.Add(dot.Copy());

            }
        }
    }

    public static int CompareByLine(Line line, Dot dot)
    {
        float x1 = line.dot1.x; float y1 = line.dot1.z;
        float x2 = line.dot2.x; float y2 = line.dot2.z;
        float x = dot.x; float y = dot.z;
        if (x1 == x2)
            return x1.CompareTo(dot.x);
        else
        {
            return ((x2 - x1) * (y - y1) - (y2 - y1) * (x - x1)).CompareTo(0);
        }
    }
   
    public static bool TryDivide(ref Dot startDot, Dot other, Dot dot2, List<DotObject> dots, out Line line,float wait)
    {
        line = null;

        if (dot2 == other || startDot == other)
            return false;
        
        if(startDot == null)
        {
            Debug.Log("startDot == null");
            return false;
        }
        if (dot2 == null)
        {
            Debug.Log("dot2 == null");
            return false;
        }
        if (startDot.z == dot2.z && startDot.CompareTo(dot2)==0)
            return false;
        
        line = new Line(startDot.Copy(), dot2.Copy());
        int abs = CompareByLine(line, other.Copy());
        if (abs == 0)
        {
            line = null;
            return false;
        }
            

        
        
        int count1, count2;
        count1 = count2 = 0;
        int resOfComparison;
        foreach (DotObject dotGO in dots)
        {
            resOfComparison = CompareByLine(line, dotGO.dot);
            if (resOfComparison == 0)
                continue;
            else if (resOfComparison < 0)
            {
                count1++;
            }
            else
            {
                count2++;
            }
           

        }
        
        bool res;
        if (abs < 0)
            res = count2 == 0;
        else
            res = count1 == 0;
        if (!res)
        {
            line.DeleteLineInWorld(wait);
            line = null;
        }
        else
        {
            startDot = dot2.Copy();

        }
        
        return res;
    }

}
