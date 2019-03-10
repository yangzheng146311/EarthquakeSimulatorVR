using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_S2 :MySceneManager {

    //指示点组
    public GameObject DesGroup;
    //当前显示的指示点序号
    public int DesIndex;
    //地震控制器
    public GameObject EarthQuakeController;
    //第一次坍塌是否发生
    private bool FirstFloorDevastated = false;
    //第二次坍塌是否发生
    private bool SecondFloorDevastated = false;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        DesIndex = 0;
        NextScene = "Simulation_3";
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        
        if(DesGroup.transform.GetChild(DesIndex)!=null)
        DesGroup.transform.GetChild(DesIndex).gameObject.SetActive(true);

        if (TipsIndex == 4 && !FirstFloorDevastated)
        {
            FirstShake();
            FirstFloorDevastated = true;
        }

        if (TipsIndex == 9 && !SecondFloorDevastated)
        {
            SecondShake();
            SecondFloorDevastated = true;
        }



    }

    public void SetDesGroupActivate()
    {
        DesGroup.SetActive(true);
    }

    private void FirstShake()
    {
        EarthQuakeController.GetComponent<EarthQuakeController_S2>().StartDestroyFloorOne();

    }

    private void SecondShake()
    {
        EarthQuakeController.GetComponent<EarthQuakeController_S2>().StartDestroyFloorSecond();

    }

}
