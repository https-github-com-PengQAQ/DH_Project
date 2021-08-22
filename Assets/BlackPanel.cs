using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackPanel : MonoBehaviour
{
    private GameObject image; //设置图片
    private Image rawImage;//设置rawimage
    public float speed = 3f;
    //屏幕是否要逐渐清晰(默认是需要的)
    private bool isclear = true;
    //屏幕是否需要逐渐变暗(默认是不需要的)
    private bool isblack = true;
    public Color beginColor;
    public void Awake()
    {
        //base.Awake();
        image = this.gameObject;
        rawImage = this.GetComponent<Image>();
        beginColor = rawImage.color;
    }
    public void Start()
    {
        //rawImage.color = 
        Debug.Log("Fade into");
    }
    /// <summary>
    /// 淡入效果
    /// </summary>
    public void fadetoClear()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.clear, speed * Time.deltaTime);
    }
    /// <summary>
    /// 淡出效果
    /// </summary>
    public void fadetoBlack()
    {
        rawImage.color = Color.Lerp(rawImage.color, Color.black, speed * Time.deltaTime);
    }

    public void SceneToClear()
    {
        fadetoClear();
        if (rawImage.color.a < 0.05f)
        {
            rawImage.color = Color.clear;
            init();
            //rawImage.enabled = false;
            //isclear = false;
        }
    }

    public void SceneToBlack()
    {
       // rawImage.enabled = true;
        fadetoBlack();
        if (rawImage.color.a > 0.95f)
        {
            rawImage.color = Color.black;
            isblack = false;
            //rawImage.color = beginColor;
            //this.gameObject.SetActive(false);
        }
    }

    public void init()
    {
        isblack = true;
        rawImage.color = Color.black;
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        if(isblack)
            SceneToBlack();
        else
            SceneToClear();
        
    }
}
