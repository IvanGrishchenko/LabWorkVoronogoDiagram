using System.Collections;
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
        //dotObjectsArray = new DotObject[5];
        //dotObjectsArray[2] = new DotObject(new Dot(-10, 10));
        //dotObjectsArray[1] = new DotObject(new Dot(-10, -10));
        //dotObjectsArray[0] = new DotObject(new Dot(10, 10));
        //dotObjectsArray[3] = new DotObject(new Dot(10, -10));
        //dotObjectsArray[4] = new DotObject(new Dot(0, 0));
        dotObjectsArray = new DotObject[length];
        for (int i = 0; i < length; ++i)
        {
            dotObjectsArray[i] = new DotObject(NextRandomDot());
        }
    }
    Dot NextRandomDot()
    {
        return new Dot(sizeOfArea.x*(0.5f - (float)random.NextDouble()), sizeOfArea.y *  (0.5f - (float)random.NextDouble()));
    }
    
}
