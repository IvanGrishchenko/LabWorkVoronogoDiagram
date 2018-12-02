using System.Collections;
using System.Collections.Generic;
using UnityEngine;using System;

public class DotObject  : IComparable{
    public int CompareTo(object o)
    {
        if(this.dot==null)
            throw new Exception("cannot compare two objects this.dot==null");
        DotObject dot = o as DotObject;
        if (dot != null)
            return this.dot.CompareTo(dot.dot);
        else
            throw new Exception("cannot compare two objects   dot != null");
    }
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
        wasCreated = true;
    }
    
	
}
