using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    public void Tick(Transform follow, Vector3 moveInput)
    {
        Vector3 cameraForward = follow.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 playerMoveDirection = follow.right;

        Vector3 movementDirection = (cameraForward * moveInput.z + playerMoveDirection * moveInput.x).normalized;

        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);
        }

        Vector3 movement = movementDirection * moveSpeed * Time.deltaTime;

        transform.position += movement;
    }
}
