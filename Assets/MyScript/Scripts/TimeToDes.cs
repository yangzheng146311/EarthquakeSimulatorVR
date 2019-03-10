using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeToDes : MonoBehaviour {
    float time = 0;
    GameObject brokensound;
    public float DestroyTime=3.0f;
     AudioSource _audio;
    // Use this for initialization
    private void Awake()
    {
        _audio = this.GetComponent<AudioSource>();
    }
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (time > DestroyTime)
        {
            DestroyLamp();
        }
	}

    void DestroyLamp()
    {
        
        if (this.GetComponent<FracturedObject>().enabled == false)
            this.GetComponent<FracturedObject>().enabled = true;

        if (_audio)
            _audio.enabled = true;



    }
}
