using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_S1 : MySceneManager{
    //书包
    public GameObject Bag;
    //课桌
    public GameObject Desk;

    //地震控制器
    public GameObject EarthquakeObj;


    //出口点
    public GameObject EntrancePoint;

    //是否已经地震过
    public bool HadBeenShaked = false;

    //是否已经出过提示语
    private bool isShowTips = false;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        NextScene = "Simulation_2";
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();

        //如果地震结束,马上显示逃生提示语
        if (ifEarthQuakeOver())
        {
            if (isShowTips == false)
            {
                base.ShowTips();
                isShowTips = true;
                base.TipsIndex++;//跳过开头地震倒数语
                base.ShowTipsVoice();
            }
            
        }
        
	}

    //取消高亮桌子
    public void SetDeskUnHightLight()
    {
        Desk.GetComponent<shaderGlow>().enabled = false;

    }

    //高亮书包
    public void SetBagHightLight()
    {
        Bag.GetComponent<shaderGlow>().enabled = true;

    }

    //课室场景地震
    public void ShakeClassromm()
    {
        EarthquakeObj.GetComponent<EarthQuakeController_S1>().EarthQuakeTrigger();
        HadBeenShaked = true;

    }

    //判断是否地震结束
    private bool ifEarthQuakeOver()
    {
        return ((!EarthquakeObj.GetComponent<EarthQuakeController_S1>().isEarthQuakeRunning) &&(HadBeenShaked));
    }

    public void SetEntranceTrigger()
    {
        EntrancePoint.SetActive(true);
    }





   

}
