using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pair  {
    public Pair(Dot dot1,Dot dot2)
    {
        this.dot1 = dot1;
        this.dot2= dot2;
    }

    public Dot dot1;
    public Dot dot2;
    public Vector3 toVector3()
    {
        return new Vector3(dot2.deltaX(dot1) ,0, dot2.deltaZ(dot1));
    }
    public Vector3 GetMiddlePos()
    {
        return new Vector3(dot2.GetMiddleX(dot1),0, dot2.GetMiddleZ(dot1));
    }

}
