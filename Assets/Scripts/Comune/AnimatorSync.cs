using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class AnimatorSync : MonoBehaviourPun
{
    Animator anim;
    PhotonView view;

    // Update is called once per frame
    public void Init()
    {
        anim = GetComponent<Animator>();
        view = PhotonView.Get(this);
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
    
    [PunRPC]
    public void SyncronizeAnimation(string animName)
    {
        anim.Play(animName);
        Debug.Log("connection attack");
    }

    public void PlayAnimation(string animName)
    {
        if (PhotonNetwork.IsConnected)
        {
            if (view == null) view = PhotonView.Get(this);
            view.RPC("SyncronizeAnimation", RpcTarget.All, animName);
        }
        else
        {
            anim.Play(animName);
        }
    }

}
