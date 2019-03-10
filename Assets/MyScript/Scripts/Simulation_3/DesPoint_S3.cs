using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;
public class DesPoint_S3 : VRTK_DestinationPoint
{
    private SceneManager_S3 sceneManager;
    protected override void Awake()
    {
        base.Awake();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_S3>();
    }
    protected override void DisablePoint()
    {
        base.DisablePoint();


        sceneManager.TipsIndex++;
        sceneManager.ShowTipsVoice();

        if (!gameObject.name.Equals("NoAddIndexDes"))
            sceneManager.DesIndex++;

        gameObject.SetActive(false);

    }



}
