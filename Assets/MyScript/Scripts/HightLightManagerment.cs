using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HightLightManagerment : MonoBehaviour {

    VRTK_ControllerHighlighter highlighter;
    VRTK_ControllerTooltips Tooltips;
    VRTK_ControllerEvents events;

    public string triggerText = "";
    public string touchpadText = "";
    public string gripText = "";
    public VRTK_ControllerTooltips GetTooltips
    {
        get
        { return Tooltips; }

    }

    // Use this for initialization
    void Start() {
        highlighter = gameObject.GetComponent<VRTK_ControllerHighlighter>();
        Tooltips = transform.GetChild(0).GetComponent<VRTK_ControllerTooltips>();
        events = GetComponent<VRTK_ControllerEvents>();

        

        events.TriggerPressed += Events_TriggerPressed;
        events.TriggerReleased += Events_TriggerReleased;
        events.TouchpadPressed += Events_TouchpadPressed;
        events.TouchpadReleased += Events_TouchpadReleased;
        events.GripReleased += Events_GripReleased;
        events.GripPressed += Events_GripPressed;
        
       
       


    }

   



    // Update is called once per frame
    void Update() {

        


    }


   


    private void Events_GripPressed(object sender, ControllerInteractionEventArgs e)
    {
        highlighter.HighlightElement(SDK_BaseController.ControllerElements.GripLeft, Color.yellow);
        highlighter.HighlightElement(SDK_BaseController.ControllerElements.GripRight, Color.yellow);
        VRTK_ObjectAppearance.SetOpacity(VRTK_DeviceFinder.GetModelAliasController(gameObject), 0.5f);
    }

    private void Events_GripReleased(object sender, ControllerInteractionEventArgs e)
    {
        highlighter.UnhighlightElement(SDK_BaseController.ControllerElements.GripLeft);
        highlighter.UnhighlightElement(SDK_BaseController.ControllerElements.GripRight);
        VRTK_ObjectAppearance.SetOpacity(VRTK_DeviceFinder.GetModelAliasController(gameObject), 1.0f);
    }

    private void Events_TouchpadReleased(object sender, ControllerInteractionEventArgs e)
    {
        highlighter.UnhighlightElement(SDK_BaseController.ControllerElements.Touchpad);
        VRTK_ObjectAppearance.SetOpacity(VRTK_DeviceFinder.GetModelAliasController(gameObject), 1.0f);
    }

    private void Events_TouchpadPressed(object sender, ControllerInteractionEventArgs e)
    {
        highlighter.HighlightElement(SDK_BaseController.ControllerElements.Touchpad,Color.yellow);
        VRTK_ObjectAppearance.SetOpacity(VRTK_DeviceFinder.GetModelAliasController(gameObject), 0.5f);
    }

    private void Events_TriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        highlighter.UnhighlightElement(SDK_BaseController.ControllerElements.Trigger);
        VRTK_ObjectAppearance.SetOpacity(VRTK_DeviceFinder.GetModelAliasController(gameObject), 1.0f);
    }

    private void Events_TriggerPressed(object sender, ControllerInteractionEventArgs e)
    {

        highlighter.HighlightElement(SDK_BaseController.ControllerElements.Trigger, Color.yellow);
        VRTK_ObjectAppearance.SetOpacity(VRTK_DeviceFinder.GetModelAliasController(gameObject), 0.5f);



    }







}
