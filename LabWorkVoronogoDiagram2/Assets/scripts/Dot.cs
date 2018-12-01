using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot  {
    
    public float x;
    public float z;
    public float deltaX(Dot dot)
    {
        return this.x - dot.x;
    }
    public float deltaZ(Dot dot)
    {
        return this.z - dot.z;
    }
    public float GetMiddleX(Dot dot)
    {
        return (x + dot.x) / 2;
    }
    public float GetMiddleZ(Dot dot)
    {
        return (z + dot.z) / 2;
    }
    public Vector3 toVector3()
    {
        return new Vector3(x, 0, z);
    }


}
