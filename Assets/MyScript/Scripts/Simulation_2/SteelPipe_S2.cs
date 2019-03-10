using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelPipe_S2 : MonoBehaviour
{
    private AudioSource _audio;
    
    private SceneManager_S2 sceneManager;
    bool isHited = false;


    // Use this for initialization
    void Start()
    {
        _audio = this.GetComponent<AudioSource>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_S2>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.name.Equals("FlashLight"))
        {
            _audio.Play();
            if (!isHited)
            {
                sceneManager.TipsIndex++;
                sceneManager.ShowTipsVoice();
                sceneManager.DesIndex++;
            }
            isHited = true;
        }
    }
}
