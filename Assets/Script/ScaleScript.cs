using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    public float _width = 110000.0f;
    public float _height = 6000.0f;
    public float _depth = 50000.0f;

    float _ratioWidth = 12f;
    float _ratioHeight = 12f;
    float _ratioDepth = 12f;

    public void SetWidth(float width)
    {    
        _ratioWidth = width/ _width;
        transform.localScale = new Vector3(_ratioWidth, _ratioDepth, _ratioHeight);

    }
    public void SetHeight(float height)
    {

        _ratioHeight = height / _height;
        transform.localScale = new Vector3(_ratioWidth, _ratioDepth, _ratioHeight);
    }
    public void SetDepth(float depth)
    {
        _ratioDepth = depth / _depth;
        transform.localScale = new Vector3(_ratioWidth, _ratioDepth, _ratioHeight);
    }
}
