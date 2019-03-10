using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class AlarmButton : VRTK_InteractableObject {
    Animator _ani;
    AudioSource _audio;
    private SceneManager_F1 sceneManager;

    private bool isPressed = false;

    // Use this for initialization
    void Start () {
        _ani = gameObject.GetComponent<Animator>();
        _audio = gameObject.GetComponent<AudioSource>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_F1>();
    }

    public override void StartUsing(VRTK_InteractUse usingObject)
    {
        base.StartUsing(usingObject);

        _ani.SetBool("isAlarmOn", true);

        if (isPressed == false)
        {
            isPressed = true;
            _audio.Play();
            sceneManager.TipsIndex++;
            sceneManager.ShowTipsVoice();
            sceneManager.DesIndex++;
        }
        

    }
}
