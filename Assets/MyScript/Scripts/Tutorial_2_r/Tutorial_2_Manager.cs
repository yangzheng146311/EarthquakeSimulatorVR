using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial_2_Manager :MySceneManager
{
    public GameObject Pipe;
    // Use this for initialization
    protected override void Start () {
        base.Start();
        NextScene = "Entrance_";
	}

    // Update is called once per frame
    protected override void Update () {
        
        base.Update();
        
    }

    public void SetPipeHightLight()
    {
        Pipe.gameObject.GetComponent<shaderGlow>().enabled = true;
        Pipe.transform.GetComponent<BoxCollider>().enabled = true;

    }
}
