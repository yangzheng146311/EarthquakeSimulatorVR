using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_F1 : MySceneManager {

    //笔记本电脑
    public GameObject LapTop;
    //讲台桌子
    public GameObject Desk;
    //电闸
    public GameObject Switch;
    //警铃
    public GameObject Alarm;

    bool ifFinishedTask = false;

    //开始燃烧桌子的时间
    public float startBurnTime = 5.0f;
    //目前的时间
    private float curTime = 0.0f;

    //是否已经发生爆炸
    public bool HadBeenExploed = false;

    //指示点组
    public GameObject DesGroup;
    //当前显示的指示点序号
    public int DesIndex;

    //是否展现指示点组
    private bool isDesGroupActivated = false;


    protected override void Start()
    {
        base.Start();
        DesIndex = 0;
        NextScene = "Entrance_Test";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //如果发生爆炸，将准备燃烧倒数燃烧桌子
        if(HadBeenExploed==true)
        {
            CountDownBurnTable();
        }

        if (DesGroup.transform.GetChild(DesIndex) != null&&isDesGroupActivated)
            DesGroup.transform.GetChild(DesIndex).gameObject.SetActive(true);


        
    }

    //展示指示点组
    public void SetDesGroupActivated()
    {

        isDesGroupActivated = true;

    }
    //开始爆炸
    public void StartExplode()
    {
        LapTop.GetComponent<Laptop>().ExplodeHappens();

        base.ShowTips();
    }

     //倒数烧桌子
     private void CountDownBurnTable()
    {
        if (curTime < 5.0f)
            curTime += Time.deltaTime;
        else
            if(Desk.GetComponent<MyTable>().isBurning==false)
            StartBurnDesk();


    }

    //关闭警铃
    public void TurnOffAlarm()
    {
        Alarm.GetComponent<AudioSource>().Stop();
    }

    //燃烧桌子
    public void StartBurnDesk()
    {
        Desk.GetComponent<MyTable>().BurnTable();

    }

    public void EliminateLaptopSpark()
    {
        Destroy(LapTop.transform.Find("flare").gameObject);
        LapTop.GetComponent<AudioSource>().enabled = false;
    }

    }
