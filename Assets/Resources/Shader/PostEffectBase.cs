using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 屏幕后处理基类
/// </summary>
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PostEffectBase:MonoBehaviour
{
    [Header("后处理着色器")]
    public Shader shader = null;

    private Material _material = null;

    public Material material
    {
        get
        {
            if (_material == null)
            {
                _material = GenerateMaterial(shader);
            }
            return _material;
        }
    }

    protected Material GenerateMaterial(Shader shader)
    {
        if (shader == null || shader.isSupported == false)
        {
            return null;
        }
        Material material = new Material(shader);
        material.hideFlags = HideFlags.DontSave;
        if (material)
        {
            return material;
        }
        return null;
    }
}
