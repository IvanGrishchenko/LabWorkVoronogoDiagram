using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyUtilities  {
   public static Vector3 Multiply(this Vector3 thisV,Vector3 multV)
    {
        return new Vector3(thisV.x * multV.x, thisV.y * multV.y, thisV.z * multV.z);
    }
	
}
