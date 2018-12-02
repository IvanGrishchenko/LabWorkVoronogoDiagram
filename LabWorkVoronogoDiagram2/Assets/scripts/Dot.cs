using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Dot : IComparable{
    public int CompareTo(object o)
    {
        Dot dot = o as Dot;
        if (dot != null)
            return this.x.CompareTo(dot.x);
        else
            throw new Exception("cannot compare two objects");
    }
    public Dot(float x , float z)
    {
        this.x = x;
        this.z = z;
    }
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
<<<<<<< HEAD
    public override string ToString()
    {
        return this.x + " " + this.z;
    }
   public bool compare(Dot dot2)
    {
        return !(dot2.x != this.x || dot2.z != this.z);
    }
=======


>>>>>>> parent of 001ed33... Готов метод Эндрю-Джарвиса
}
