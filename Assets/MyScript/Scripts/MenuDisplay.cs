using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
public class MenuDisplay : MonoBehaviour {
    VRTK_ControllerEvents events;
    GameObject _menu;
    
    // Use this for initialization
    void Start () {
        events = GetComponent<VRTK_ControllerEvents>();
        events.ButtonTwoPressed += new ControllerInteractionEventHandler(MenuPressed);
        _menu = GameObject.FindGameObjectWithTag("Menu");
       
    }

    private void MenuPressed(object sender, ControllerInteractionEventArgs e)
    {

        //改变菜单可见状态
        ChangeCanvasSatus();
    }

    // Update is called once per frame
    void Update () {
		
	}

    
    void ChangeCanvasSatus()
    {
        //for (int i = 0; i < _menu.transform.childCount; i++)
        //{
        //    _menu.transform.GetChild(i).GetComponent<Canvas>().enabled = (_menu.transform.GetChild(i).GetComponent<Canvas>().enabled == true) ? false : true;
        //}
        _menu.SetActive(_menu.gameObject.activeSelf ? false : true);
       
    }

   



    
}
