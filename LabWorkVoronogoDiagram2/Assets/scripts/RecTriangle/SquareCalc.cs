using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SquareCalc {
    public static float calculatedArea(Line Foundation, Dot Vertex, ref float MaxArea, float wait, ref Line Side1, ref Line Side2)
    {

        Line TempSide1 = new Line(Foundation.dot1.Copy(), Vertex.Copy());
        Line TempSide2 = new Line(Foundation.dot2.Copy(), Vertex.Copy());
        Vector3 v1 = TempSide1.toVector3();
        Vector3 v2 = Foundation.toVector3();
        float Area = Mathf.Abs(Vector3.Cross(v1, v2).magnitude * 0.5f);

        if (Area > MaxArea || (Area == MaxArea && Vector3.Angle(Foundation.toVector3(),v1)>Vector3.Angle(Foundation.toVector3(), Side1.toVector3())))
        {
            MaxArea = Area;
            if (Side1 != null)
                Side1.DeleteLineInWorld();
            if (Side2 != null)
                Side2.DeleteLineInWorld();
            Side1 = TempSide1;
            Side2 = TempSide2;
        }
        else
        {
            TempSide1.DeleteLineInWorld();
            TempSide2.DeleteLineInWorld();
        }
        
          
     
       

        return Area;
    }
}
