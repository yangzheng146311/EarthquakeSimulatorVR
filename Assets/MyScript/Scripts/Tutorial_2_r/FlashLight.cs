using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class FlashLight : VRTK_InteractableObject
{
    private GameObject SpotLight;
    private bool isOpened = false;
    private Tutorial_2_Manager sceneManager;
    public bool isUsed = false;
    

    protected override void Awake()
    {
        base.Awake();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Tutorial_2_Manager>();
       
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

       
        if (!isOpened)
            OpenSpotLight();
        else
            OffLight();

        isUsed = true;
    }

    private void OpenSpotLight()
    {
        Debug.Log(sceneManager.TipsIndex);
        SpotLight.SetActive(true);
        isOpened = true;
        Debug.Log("开灯");
        if (isUsed == false)
        {
            sceneManager.TipsIndex++;
            sceneManager.ShowTipsVoice();
            sceneManager.SetPipeHightLight();
        }
    }

    private void OffLight()
    {
        Debug.Log("关灯");
        SpotLight.SetActive(false);
        isOpened = false;

    }
}
