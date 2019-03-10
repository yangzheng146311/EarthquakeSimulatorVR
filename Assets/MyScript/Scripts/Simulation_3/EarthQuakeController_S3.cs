using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeController_S3 : MonoBehaviour
{

    //地震组件
    private EarthQuake _earthquake;

    //地震音频
    public AudioSource _audio;



    // Use this for initialization
    void Start()
    {
        _earthquake = gameObject.GetComponent<EarthQuake>();

    }

    // Update is called once per frame
    void Update()
    {

    }




    //地面震动
    private void StartEarthquake()
    {
        _audio.enabled = true;
        if (_audio)
            _audio.Play();
        _earthquake.Running = true;

    }

    //震动操场
    public void ShakePlaygound()
    {
        StartEarthquake();

    }

    





}
