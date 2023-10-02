using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
    [SerializeField] Image icon = null;
    [SerializeField] Image countdownImage = null, onOffImage = null;
    [SerializeField] Text buttontext = null;
    ActionClass action;
    ActionController controller;

    public void SetUpButton(ActionController controller, ActionClass action)
    {
        this.action = action;
        this.controller = controller;
        buttontext.text = changeAlphaText(this.action.key.ToString());
        var skill = action.skill;
        if (skill != null)
        {
            icon.sprite = skill.sprite;
        }
    }

    public void Pressed()
    {
        controller.PressButton(action);
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

    public void ManaCheck()
    {
        if (action.skill == null) return;
        if (action.skill.cost <= controller.mana)
        {
            onOffImage.enabled = false;
        }
        else
        {
            onOffImage.enabled = true;
        }
    }
}
