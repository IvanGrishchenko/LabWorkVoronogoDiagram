﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour {
    public static LogicManager ins;
    private void Awake()
    {
        ins = this;
    }
    public int length;
    public Vector2 sizeOfArea;
    static System.Random random = new System.Random();
    public DotObject dotGO;
    public DotObject[] dotObjectsArray;
    // Use this for initialization

	
	// Update is called once per frame
	void Update () {
		
	}
    public void CreateArray()
    {
        CreateArray(length);
    }
    void CreateArray(int length)
    {
        dotObjectsArray = new DotObject[length];
        for(int i = 0; i < length; ++i)
        {
            dotObjectsArray[i] = new DotObject(NextRandomDot());
        }
    }
    Dot NextRandomDot()
    {
        return new Dot(sizeOfArea.x*(0.5f - (float)random.NextDouble()), sizeOfArea.y *  (0.5f - (float)random.NextDouble()));
    }
    
}
