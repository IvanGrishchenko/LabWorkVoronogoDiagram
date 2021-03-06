﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : Pair {
    public Line(Dot dot1, Dot dot2):base(dot1,dot2)
    {
        CreateLineInWorld();
    }
    float Width = 0.3f;
    public Color color;
    bool isDrawn;
    public GameObject lineGameObject;

    public Line(Dot dot1, Dot dot2, Color color) :  this(dot1, dot2)
    {
        lineGameObject.GetComponent<Renderer>().material.color = color;
    }
    public Line(Dot dot1, Dot dot2, Color color,float Scalefactor) : base(dot1, dot2)
    {
        
        Width *= Scalefactor;
        CreateLineInWorld();
        lineGameObject.GetComponent<Renderer>().material.color = color;
        Width /= Scalefactor;
    }


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
        lineGameObject.transform.localScale = new Vector3(Width, Width, toVector3().magnitude);

    }
    public void DeleteLineInWorld(float wait = 0)
    {
        GameObject.Destroy(lineGameObject,wait );
        isDrawn = false;
    }





}
