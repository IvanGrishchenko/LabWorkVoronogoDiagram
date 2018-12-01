using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : Pair {
    public Line(Dot dot1, Dot dot2):base(dot1,dot2)
    {
        CreateLineInWorld();
    }
    public Color color;
    bool isDrawn;
    public GameObject lineGameObject;
    public void CreateLineInWorld()
    {
        Quaternion q = Quaternion.LookRotation(toVector3());
        if (isDrawn)
        {
            if(lineGameObject == null)
            {
                Debug.LogError("object was deleted by someone else");
            }
            else
            {
                GameObject.Destroy(lineGameObject);
            }
        }
        isDrawn = true;
        lineGameObject = GameObject.Instantiate(ReferenceManager.ins.cube,GetMiddlePos(),q, ReferenceManager.ins.parent);
        lineGameObject.transform.localScale = new Vector3(1,1,toVector3().magnitude);

    }
    public void DeleteLineInWorld()
    {
        GameObject.Destroy(lineGameObject);
        isDrawn = false;
    }





}
