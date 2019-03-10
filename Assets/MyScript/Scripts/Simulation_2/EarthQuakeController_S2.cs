using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthQuakeController_S2 : MonoBehaviour
{

    //地震组件
    private EarthQuake _earthquake;

    //第一次坍塌的楼
    public Transform floor_1;
    //第二次坍塌的楼
    public Transform floor_2;
    //第一次出现的烟雾
    public GameObject Smoke_1;
    //第二次出现的烟雾
    public GameObject Smoke_2;


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

    //第一次坍塌
    public void StartDestroyFloorOne()
    {
        StartEarthquake();
        DestroyFloor(floor_1);
        if (Smoke_1)
            Smoke_1.SetActive(true);
    }
    //第二次坍塌
    public void StartDestroyFloorSecond()
    {
        StartEarthquake();
        DestroyFloor(floor_1);
        DestroyFloor(floor_2);
        if (Smoke_2)
            Smoke_2.SetActive(true);
    }

    //坍塌楼道
    void DestroyFloor(Transform floor)
    {
        if (floor != null)
        {
            for (int i = 0; i < floor.transform.childCount; i++)
            {
                if (!floor.GetChild(i).gameObject.GetComponent<Rigidbody>())
                    floor.GetChild(i).gameObject.AddComponent<Rigidbody>();
            }
        }

    }





}
