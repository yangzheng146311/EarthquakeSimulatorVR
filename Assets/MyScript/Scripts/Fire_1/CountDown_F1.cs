using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountDown_F1 : MonoBehaviour {

    private Text Count_txt;
    public float maxTime = 5.0f;
    private float curTime = 5.0f;
    private SceneManager_F1 sceneManager;

    // Use this for initialization
    void Start()
    {
        Count_txt = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_F1>();
    }

    // Update is called once per frame
    void Update()
    {

        //倒计时演习
        if (curTime > 0)
        {
            curTime = maxTime -= Time.deltaTime;
            Count_txt.text = string.Format("演习将于{0}秒后开始", ((int)curTime).ToString());
        }

        else
        {

            gameObject.SetActive(false);

            //如果未发生过爆炸,则触发爆炸
            if (sceneManager.HadBeenExploed == false)
            {
                sceneManager.HadBeenExploed = true;
                sceneManager.StartExplode();
                //跳过倒数提示语
                sceneManager.TipsIndex++;
                sceneManager.ShowTipsVoice();
               
            }

        }
    }


}
