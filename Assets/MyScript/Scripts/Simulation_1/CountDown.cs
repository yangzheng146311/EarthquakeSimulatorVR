using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    private Text Count_txt;
    public float maxTime = 5.0f;
    private float curTime = 5.0f;
    private SceneManager_S1 sceneManager;

    // Use this for initialization
    void Start () {
        Count_txt = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManager_S1>();
    }
	
	// Update is called once per frame
	void Update () {

        //倒计时地震
        if (curTime > 0)
        {
            curTime = maxTime -= Time.deltaTime;
            Count_txt.text = string.Format("地震将于{0}秒后发生", ((int)curTime).ToString());
        }

        else
        {
            
            gameObject.SetActive(false);

            //如果未发生过地震,则触发地震
            if (sceneManager.HadBeenShaked == false)
            {
                sceneManager.ShakeClassromm();
                sceneManager.SetDeskUnHightLight();
                sceneManager.SetBagHightLight();
            }

        }
    }
}
