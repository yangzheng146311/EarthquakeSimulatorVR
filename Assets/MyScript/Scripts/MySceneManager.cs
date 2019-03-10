using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Crosstales.RTVoice;
public class MySceneManager : MonoBehaviour {



    //提示的Canvas
    private GameObject Canvas_Tips;

    //进度条Bar
    private GameObject Canvas_Bar;

    //下一场景
    protected string NextScene;

    //滑动条
    Slider slider;
    //进度条时间
    float staytime = 10.0f;
    //进度条进行时间
    float curtime = 0;

    //是否已经读条完成
    bool isBarFilled = false;
    public bool FilledBar
    {
        get { return isBarFilled; }
        set { isBarFilled = value; }
    }

   


    //提示语总数
    private int TipsAmount;
    //当前的提示序号
    private int tipsIndex;
    public int TipsIndex
    {
        get { return tipsIndex; }
        set { tipsIndex = value; }
    }

    //用于存储提示字符组的脚本
    ToolTipsTest ToolTipsTest;

    //提示的Canvas的文本
    Text _tips;

    //文本访问器
    public string getTips
    {
        get { return _tips.text; }
        set { _tips.text = value; }
        
    }

  
    // Use this for initialization

    protected void Awake()
    {
        
        Canvas_Tips =GameObject.FindGameObjectWithTag("Tips");
        Canvas_Bar = GameObject.FindGameObjectWithTag("Bar");
        
    }
    protected virtual void Start () {

        tipsIndex = 0;
        ToolTipsTest = Canvas_Tips.GetComponent<ToolTipsTest>();
        _tips = Canvas_Tips.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        TipsAmount = ToolTipsTest.ToolTipsSize;
        slider = Canvas_Bar.transform.GetChild(0).GetComponent<Slider>();
        SetBarDisappear();
        InitiateBar();
        _tips.text = ToolTipsTest.TipsTest[tipsIndex];
        Speaker.SpeakNative(_tips.text);
    }

    // Update is called once per frame
    protected virtual void Update () {
        _tips.text = ToolTipsTest.TipsTest[tipsIndex];

        //如场景已经结束触发进度条
        if (isSceneOver())
        {
           

            SetBarTrigger();

        }
        //如果进度条被触发 则读条
        if (Canvas_Bar.activeSelf)
            LoadBar();

        //如果是由场景结束而产生的进度条读条完毕,则跳转到下一个场景
        if (isSceneOver() && LoadBar())
            if (NextScene!=null)
            {
                if(FilledBar==true)
                SceneManager.LoadScene(NextScene);
            }
    }


    public void InitiateBar()
    {

        slider.value = 0;
        curtime = 0;
        FilledBar = false;
    }
    protected bool isSceneOver()
    {
        if (tipsIndex >= TipsAmount - 1) return true;
        else return false;
    }


    //显示逃生提示语
    protected void ShowTips()
    {
        if (!Canvas_Tips.transform.GetChild(0).gameObject.activeSelf)
            Canvas_Tips.transform.GetChild(0).gameObject.SetActive(true);
      
    }

    public void ShowTipsVoice()
    {
        if(tipsIndex<ToolTipsTest.TipsTest.Length)
        Speaker.SpeakNative(ToolTipsTest.TipsTest[tipsIndex]);


    }

    //显示进度条
    public void SetBarTrigger()
    {
        Canvas_Bar.SetActive(true);
        

    }

    //消失进度条
    public void SetBarDisappear()
    {

        Canvas_Bar.SetActive(false);
       
    }
    //读条
    protected bool LoadBar()
    {
        curtime += Time.deltaTime;
        if (slider.value < 1.0f)
        {

            slider.value = (curtime / staytime);
            return false;
        }

        else
        {
            FilledBar = true;
            TipsIndex++;
            ShowTipsVoice();
            SetBarDisappear();
            return true;
        }

    }

}
