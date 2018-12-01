using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceManager : MonoBehaviour {
    public static ReferenceManager ins;
    public GameObject cube;
    public Transform parent;
    public GameObject dot;







    private void Awake()
    {
        if (ins == null)
            ins = this;
    }
    private void OnValidate()
    {
        if (ins == null)
            ins = this;
    }
}
