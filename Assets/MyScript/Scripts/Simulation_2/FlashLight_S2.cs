using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class FlashLight_S2 : VRTK_InteractableObject
{
    private GameObject SpotLight;
    private bool isOpened = false;
    private SceneManager_S2 sceneManager;
    public bool isUsed = false;
    int times = 0;


    protected override void Awake()
    {
        base.Awake();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_S2>();

    }
    // Use this for initialization
    void Start()
    {

        SpotLight = transform.Find("MySpotlight").gameObject;
        SpotLight.SetActive(false);
        
    }

    
    
    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);

        times++;
        Debug.Log(times);
        
        if (!isOpened)
            OpenSpotLight();
        else
            OffLight();

        isUsed = true;
    }

    private void OpenSpotLight()
    {
        SpotLight.SetActive(true);
        isOpened = true;
        Debug.Log("开灯");
        if (isUsed == false)
        {
            sceneManager.TipsIndex++;
            sceneManager.ShowTipsVoice();
            sceneManager.SetDesGroupActivate();
        }
    }

    private void OffLight()
    {
        Debug.Log("关灯");
        SpotLight.SetActive(false);
        isOpened = false;

    }
}
