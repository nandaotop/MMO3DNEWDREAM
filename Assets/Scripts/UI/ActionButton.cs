using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] Image icon = null;
    [SerializeField] Image countdownImage = null, onOffImage = null;
    [SerializeField] Text buttontext = null;
    KeyCode code = KeyCode.None;
    ActionController controller;

    public void SetUpButton(ActionController controller, KeyCode key)
    {
        this.code = key;
        this.controller = controller;
        buttontext.text = changeAlphaText(key.ToString());
    }

    public void Pressed()
    {
        controller.PressButton(code);
    }

    string changeAlphaText(string buttonText)
    {
        if (buttonText == "Keypad1")
            return "1";
        if (buttonText == "Keypad2")
            return "2";
        if (buttonText == "Keypad3")
            return "3";
        if (buttonText == "Keypad4")
            return "4";
        if (buttonText == "Keypad5")
            return "5";
        if (buttonText == "Keypad6")
            return "6";

        return buttonText;
    }
}
