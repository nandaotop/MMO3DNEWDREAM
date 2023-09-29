using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AnimatorSync : MonoBehaviourPun
{
    Animator anim;

    // Update is called once per frame
    public void Init()
    {
        anim = GetComponent<Animator>();
    }

    public void Move(float x, float y)
    {
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
    }

    public void SetMove(bool val)
    {
        anim.SetBool(StaticStrings.move, val);
    }
    
    public void PlayAnimation(string animName)
    {
        if (PhotonNetwork.IsConnected)
        {

        }
        else
        {
            anim.Play(animName);
        }
    }

}
