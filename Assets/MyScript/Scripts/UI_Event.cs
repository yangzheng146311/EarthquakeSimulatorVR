using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Event : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial_1_r");
        
    }


     public void LoadSimulator()
    {
        SceneManager.LoadScene("Simulation_1");
        
    }

    public void LoadFireScene()
    {
        SceneManager.LoadScene("small_fire");

    }
}
