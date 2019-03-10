using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;
using Crosstales.RTVoice;
public class DesPoint_F1 : VRTK_DestinationPoint
{
    private SceneManager_F1 sceneManager;
    protected override void Awake()
    {
        base.Awake();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_F1>();
    }
    protected override void DisablePoint()
    {
        base.DisablePoint();
        sceneManager.TipsIndex++;
        sceneManager.ShowTipsVoice();
        gameObject.SetActive(false);
        if (!gameObject.name.Equals("NoAddIndexDes"))
            sceneManager.DesIndex++;
        else
            Destroy(gameObject);

    }

}
