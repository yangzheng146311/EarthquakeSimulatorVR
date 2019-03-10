using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTable : MonoBehaviour {
    //桌子材质
    private Material _mat;
    //桌子的火焰
    private Transform _fire;
    //是否燃烧中
    bool isIgnite = false;
    //桌子上的纸张
    private Transform Papers;
    //桌子上的书本
    private Transform Books;
    //桌子旁边的火焰粒子
    private Transform LittleThings;
    float eliminateTime = 3.0f;

    private AudioSource _audio;
    
    //是否完成灭火
    bool ifFinished = false;
    //是否在燃烧
    public bool isBurning = false;
    private SceneManager_F1 sceneManager;


    // Use this for initialization
    void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_F1>();
        _fire = transform.Find("flare");
        Papers = transform.Find("Papers");
        Books = transform.Find("Books");
        LittleThings = transform.Find("LittleThings");
        _mat = gameObject.GetComponent<MeshRenderer>().materials[0];
        _audio = gameObject.GetComponent<AudioSource>();

        //开始将火焰设为无
        if (_fire)    _fire.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
    }

  

    //燃烧桌子
    public void BurnTable()
    {
        //开始燃烧桌子
        isBurning = true;
        //播放火焰燃烧的声音
        _audio.Play();
        //生成火焰
        _fire.gameObject.SetActive(true);

        //桌子碳化
        _mat.color = Color.black;

        //纸张碳化
        Papers.GetComponent<MeshRenderer>().materials[0].color = Color.black;

        //书本碳化
        for (int i = 0; i < Books.transform.childCount; i++)
        {
            Books.transform.GetChild(i).GetComponent<MeshRenderer>().materials[0].color = Color.black;
        }

        //生成火焰粒子
        LittleThings.gameObject.SetActive(true);

        sceneManager.TipsIndex++;
        sceneManager.ShowTipsVoice();
        sceneManager.SetDesGroupActivated();
    }


    private void OnTriggerStay(Collider other)
    {
        
        if (other.tag.Equals("water"))
        {
            if (eliminateTime > 0)
                eliminateTime -= Time.deltaTime;
            else
            {
                isBurning = false;

                Destroy(_fire.gameObject);
                sceneManager.EliminateLaptopSpark();

                if (ifFinished == false)
                {
                    ifFinished = true;
                    sceneManager.TipsIndex++;
                    sceneManager.ShowTipsVoice();
                    transform.GetComponent<AudioSource>().enabled = false;
                    sceneManager.TurnOffAlarm();
                }


            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (isBurning == false) return;
        else
        {
            if (other.tag.Equals("water"))
            {

                eliminateTime = 3.0f;

            }
        }
    }
}
