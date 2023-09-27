using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    CameraFollow follow;
    [SerializeField] float rotSpeed = 2;
    float scroolAmount = 3;
    [SerializeField] float minZoon = 10, maxZoom = 120;
    ActionController controller;

    public override void Init()
    {
        base.Init();
        if (!photonView.IsMine) return;
        controller = GetComponent<ActionController>();
        var f = Resources.Load<CameraFollow>(StaticStrings.follow);
        follow = Instantiate(f, transform.position, transform.rotation);
        follow.Init(transform);
    }

    public override void Tick()
    {
        UseCamera();
        if (!CamMove()) return;

        float x = Input.GetAxisRaw(StaticStrings.horizontal);
        float y = Input.GetAxisRaw(StaticStrings.vertical);
        Vector3 moveInput = new Vector3(x, 0f, y).normalized;
        moveInput *= Time.deltaTime * moveMultipler * moveSpeed;
        moveInput.y = rb.velocity.y;
        rb.velocity = moveInput;

        sync.Move(x, y);
        
        controller.Tick(follow.transform, moveInput);
    }

    void UseCamera()
    {
        float x = Input.GetAxisRaw(StaticStrings.mouseX);
        float scrool = Input.GetAxisRaw(StaticStrings.Scrool);
        Vector3 rot = follow.transform.rotation.eulerAngles;
        follow.transform.rotation = Quaternion.Euler(rot.x, rot.y + x * rotSpeed, rot.z);
        if (scrool != 0)
        {
            float val = scroolAmount * scrool;
            val += follow.cam.fieldOfView;
            val = Mathf.Clamp(val, minZoon, maxZoom);
            follow.cam.fieldOfView = val;
        }
    }

    bool CamMove()
    {
        if(isDeath) 
            return false;

        return true;
    }
}
