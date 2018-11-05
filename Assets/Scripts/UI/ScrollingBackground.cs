using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Material mat;
    public float scalar;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        mat.SetTextureOffset("_MainTex", new Vector2(Time.time * scalar, 0));
    }
}
