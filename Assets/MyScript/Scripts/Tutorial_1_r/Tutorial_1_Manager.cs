using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_1_Manager : MySceneManager {

    //进度条
    //public GameObject Canvas_Bar;

    ////滑动条
    //Slider slider;

   

    ////进度条时间
    //float staytime = 4.0f;
    ////进度条进行时间
    //float curtime = 0;
    ////是否已经读条完成
    //public bool FilledBar = false;
    //书包
    public GameObject Bag;
    //课桌
    public GameObject Desk;


    protected override void Start()
    {
        base.Start();
        NextScene = "Tutorial_2_r";
      // slider = Canvas_Bar.transform.GetChild(0).GetComponent<Slider>();
    }
    protected override void Update()
    {
        base.Update();
        //if (Canvas_Bar.activeSelf)
        //    LoadBar();
      
        
    }
 
   

    //public void SetBarTrigger()
    //{
    //    Canvas_Bar.SetActive(true);
    //    slider.value = 0;
    //    curtime = 0;
    //    FilledBar = false;

    //}

    //public void SetBarDisappear()
    //{

    //    Canvas_Bar.SetActive(false);
    //}
    //private void LoadBar()
    //{
    //    curtime += Time.deltaTime;
    //    if (slider.value < 1.0f)
    //    {

    //        slider.value = (curtime / staytime);
    //    }

    //    else
    //    {
    //        FilledBar = true;
    //        TipsIndex++;
    //        SetBarDisappear();
    //    }

    //}

    public void SetDeskUnHightLight()
    {
        Debug.Log("231231312");
        Desk.GetComponent<shaderGlow>().enabled = false;

    }

    public void SetBagHightLight()
    {
        Bag.GetComponent<shaderGlow>().enabled = true;
        
    }

    
}
