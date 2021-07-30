using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance;
    [Header("控制是否使用自定义按键")]
    public bool keyIsSet;
    [Header("攻击按键")]
    public KeyCode attackKey;
    [Header("跳跃按键")]
    public KeyCode jumpKey;
    [Header("冲刺按键")]
    public KeyCode sprintKey;
    [Header("拿起物品按键")]
    public KeyCode carryKey;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        KeyInit();

    }
    public void KeyInit()
    {
        if (!keyIsSet)
        {
            attackKey = KeyCode.K;
            jumpKey = KeyCode.Space;
            sprintKey = KeyCode.J;
            carryKey = KeyCode.O;
        }
    }
}
