using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour {
    public Material blackMonitor;
    Material curMonitor;
	// Use this for initialization
	void Start () {
        curMonitor=gameObject.GetComponent<MeshRenderer>().materials[1];
	}
	
	// Update is called once per frame
	void Update () {
       
	}


   private void TurnOff()
    {
        curMonitor = blackMonitor;
        gameObject.GetComponent<MeshRenderer>().materials.SetValue(blackMonitor, 1);
        Debug.Log(curMonitor);

    }
}
