using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using UnityEngine.UI;
using Crosstales.RTVoice;
public class DesPoint_S2 : VRTK_DestinationPoint
{
    private SceneManager_S2 sceneManager;
    protected override void Awake()
    {
        base.Awake();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_S2>();
    }
    protected override void DisablePoint()
    {
        base.DisablePoint();
        sceneManager.TipsIndex++;
        sceneManager.ShowTipsVoice();
        gameObject.SetActive(false);
        if (!gameObject.name.Equals("NoAddIndexDes"))
        {
            sceneManager.DesIndex++;
        }
        else
        {
            Debug.Log("NoIndex++");
            //Destroy(gameObject);
        }




    }



}
