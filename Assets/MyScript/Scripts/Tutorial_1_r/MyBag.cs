using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBag : MonoBehaviour {
    private Tutorial_1_Manager sceneManager;
 
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
        if (other.tag.Equals("MyHead"))
        {
            sceneManager.TipsIndex++;
            sceneManager.ShowTipsVoice();
            this.gameObject.SetActive(false);
        }
    }
}
