using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotObject  {
    bool wasCreated;
    public Dot dot;
    public DotObject(Dot dot)
    {
        this.dot = dot;
        CreateDotInWorld();
    }
    public GameObject dotGameObject;
    public void CreateDotInWorld()
    {
        if (wasCreated)
        {
            if (dotGameObject == null)
            {
                Debug.LogError("object was deleted by someone else");
            }
            else
            {
                GameObject.Destroy(dotGameObject);
            }
        }
        dotGameObject = GameObject.Instantiate(ReferenceManager.ins.dot, dot.toVector3(),
            Quaternion.identity, ReferenceManager.ins.parent);
    }
	
}
