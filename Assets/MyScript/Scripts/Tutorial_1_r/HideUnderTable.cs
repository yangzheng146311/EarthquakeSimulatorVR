using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnderTable : MonoBehaviour {
    private Tutorial_1_Manager sceneManager;
    bool isLeft = false;
    private void Awake()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<Tutorial_1_Manager>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("MyHead"))
        {
            sceneManager.SetBarTrigger();
            
            //Destroy(this);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("MyHead"))
        {
            sceneManager.SetBarDisappear();
            if (sceneManager.FilledBar == true)
            {
                //离开课桌的那一刻改变提示序号1次
                if (isLeft == false)
                {
                    sceneManager.InitiateBar();
                    sceneManager.TipsIndex++;
                    sceneManager.ShowTipsVoice();
                    sceneManager.SetDeskUnHightLight();
                    sceneManager.SetBagHightLight();
                    isLeft = true;

                }
            }
        }
            
    }
}
