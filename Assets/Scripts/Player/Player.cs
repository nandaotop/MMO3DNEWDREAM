using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public override void Init()
    {
        base.Init();
    }

    public override void Tick()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 moveInput = new Vector3(x, 0f, y).normalized;

        if (moveInput != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveInput);
            rb.rotation = Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.deltaTime);

            Vector3 moveDirection = rb.rotation * Vector3.forward;
            
            rb.velocity = moveDirection * Time.deltaTime * moveMultipler * moveSpeed;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        sync.Move(x, y);
    }


}
