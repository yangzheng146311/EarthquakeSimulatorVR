using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelPipe : MonoBehaviour
{
    private AudioSource _audio;
    private shaderGlow _glow;
    private Tutorial_2_Manager sceneManager;
    bool isHited = false;


    // Use this for initialization
    void Start()
    {
        _audio = this.GetComponent<AudioSource>();
        _glow = this.GetComponent<shaderGlow>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Tutorial_2_Manager>();
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
            }
            isHited = true;
        }
    }
}
