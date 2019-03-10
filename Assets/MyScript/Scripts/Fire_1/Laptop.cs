using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : MonoBehaviour {

    //笔记本自带火光
    private Transform _fire;

    //是否冒火
    bool onFire = false;

    private AudioSource _audio;
    // Use this for initialization
    void Start()
    {
        _fire = transform.Find("flare");
        _fire.gameObject.SetActive(false);
        _audio = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {


    }

    //爆炸函数
    public void ExplodeHappens()
    {
        transform.GetComponent<Rigidbody>().AddExplosionForce(100.0f, transform.position, 2.0f, 2.0f);
        _fire.gameObject.SetActive(true);
        onFire = true;
        _audio.Play();


    }
}
