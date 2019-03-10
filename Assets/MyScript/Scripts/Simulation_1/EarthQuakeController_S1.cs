using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeController_S1 : MonoBehaviour {

    //地震组件
    private EarthQuake _earthquake;

    //破碎灯管组
    public Transform _desObject;

    //地震音频
    public AudioSource _audio;

    //地震是否进行中
    public bool isEarthQuakeRunning = false;

    // Use this for initialization
    void Start () {
        _earthquake = gameObject.GetComponent<EarthQuake>();
        
	}
	
	// Update is called once per frame
	void Update () {
        isEarthQuakeRunning = _earthquake.Running;
	}


    //触发所有地震效果
    public void EarthQuakeTrigger()
    {
        StartEarthquake();
        StartDestroyLights();

    }


    //地面震动
    private void StartEarthquake()
    {
        _audio.enabled = true;
        if (_audio)
            _audio.Play();
        _earthquake.Running = true;

    }

    //破坏灯管
    private void StartDestroyLights()
    {
        
        DestroyEverything(_desObject);
    }

    //破碎函数
    private void DestroyEverything(Transform obj)
    {
        if (obj != null)
        {

            for (int i = 0; i < obj.transform.childCount; i++)
            {
                if (obj.GetChild(i).GetComponent<TimeToDes>())
                {
                    obj.GetChild(i).GetComponent<TimeToDes>().enabled = true;
                    DestroyEverything(obj.GetChild(i));
                }
            }

        }
        else return;
    }

    



}
