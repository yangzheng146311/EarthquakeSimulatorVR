using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class FireExtin : VRTK_InteractableObject
{
    //喷口的水雾
    Transform water;
    //是否使用中
    bool isUsing = false;
    //是否已经拿起灭火器
    bool isTouched = false;
    private SceneManager_F1 sceneManager;
    private void Start()
    {
        water = transform.Find("pipeExit").transform.Find("water");
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_F1>();
    }
    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null)
    {
        base.Grabbed(currentGrabbingObject);
        if (isTouched == false)
        {
            isTouched = true;
            sceneManager.TipsIndex++;
            sceneManager.ShowTipsVoice();

        }
    }
    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);
        if (isUsing)
        {
            isUsing = false;
            water.gameObject.SetActive(false);
        }
        else
        {
            isUsing = true;
            water.gameObject.SetActive(true);
        }
            
    }
}
