using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BlackEffect : PostEffectBase
{
    [Header("黑幕半径")]
    [Space(25)]
    public float radius;

    [Header("黑幕中心")]
    public Vector2 center;

    [Header("使用边缘模糊")]
    public bool useEdgeBlur;
    [Header("边缘模糊值")]
    public float blur = 10;

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material)
        {
            material.SetFloat("_Center_X", center.x);
            material.SetFloat("_Center_Y", center.y);
            material.SetFloat("_Radius", radius);
            material.SetFloat("_Sharp", useEdgeBlur ? blur : 200);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }

    private void Start()
    {
        
    }
}
