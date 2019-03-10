using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class Switch : VRTK_InteractableObject
{
    Animator _ani;
    bool isUsed = false;
    public GameObject MonitorGroup;
    public GameObject NoMonitorGroup;
    public GameObject LampGroup;
    public GameObject SpotLightGroup;
    private SceneManager_F1 sceneManager;
    private void Start()
    {
        _ani = gameObject.GetComponent<Animator>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_F1>();
    }
    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);

        if (isUsed == false)
        {
            isUsed = true;
            _ani.SetBool("isSwitchOff", true);
            MonitorGroup.SetActive(false);
            NoMonitorGroup.SetActive(true);
            for (int i = 0; i < LampGroup.transform.childCount; i++)
            {

                LampGroup.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().materials[1].SetColor("_EmissionColor", Color.black);
            }
            SpotLightGroup.SetActive(false);

            sceneManager.TipsIndex++;
            sceneManager.ShowTipsVoice();
            sceneManager.DesIndex++;
        }
    }
}
