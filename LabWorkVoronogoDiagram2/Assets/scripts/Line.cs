using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : Pair {
    
    public Color color;
    bool isDrawn;
    GameObject line;
    public void DrawLine()
    {
        Quaternion q = Quaternion.LookRotation(toVector3());
        if (isDrawn)
        {
            if(line == null)
            {
                Debug.LogError("object was deleted by someone else");
            }
            else
            {
                GameObject.Destroy(line);
            }
        }
        isDrawn = true;
        line = GameObject.Instantiate(ReferenceManager.ins.cube,GetMiddlePos(),q, ReferenceManager.ins.parent);
        line.transform.localScale = new Vector3(1,1,toVector3().magnitude);

    }
    

    

}
