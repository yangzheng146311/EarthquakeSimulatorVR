using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;
using Crosstales.RTVoice;
public class DesPoint : VRTK_DestinationPoint
{
    private MySceneManager sceneManager;
    protected override void Awake()
    {
        base.Awake();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<MySceneManager>();
    }
    protected override void DisablePoint()
    {
        base.DisablePoint();
       
       
        sceneManager.TipsIndex++;
        sceneManager.ShowTipsVoice();
        

        gameObject.SetActive(false);

    }



}
