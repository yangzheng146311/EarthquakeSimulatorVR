using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBag_S1 : MonoBehaviour
{
    private SceneManager_S1 sceneManager;

    private void Awake()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_S1>();

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("MyHead"))
        {
            sceneManager.TipsIndex++;
            sceneManager.ShowTipsVoice();
            sceneManager.SetEntranceTrigger();
            this.gameObject.SetActive(false);
            
        }
    }
}
