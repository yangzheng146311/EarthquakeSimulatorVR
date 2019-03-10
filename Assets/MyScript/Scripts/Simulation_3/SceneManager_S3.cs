using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_S3 : MySceneManager
{

    //指示点组
    public GameObject DesGroup;
    //当前显示的指示点序号
    public int DesIndex;
    //地震控制器
    public GameObject EarthQuakeController;
    //余震是否发生
    private bool isDevastated = false;
  
    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        DesIndex = 0;
        NextScene = "Entrance_";
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(DesIndex<=3)
        DesGroup.transform.GetChild(DesIndex).gameObject.SetActive(true);
        


        if (TipsIndex == 1 && !isDevastated)
        {
            ShakePlayGrond();
            isDevastated = true;
        }

    }

    //开始地震操场
    private void ShakePlayGrond()
    {
        EarthQuakeController.GetComponent<EarthQuakeController_S3>().ShakePlaygound();

    }

    public void SetDesGroupActivate()
    {
        DesGroup.SetActive(true);
    }

   

}
