using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RotationPlayerModel : MonoBehaviourPun
{
    public float rotationSpeed = 10.0f;

    void Update()
    {
        if (!photonView.IsMine)
            return;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0; 
        cameraRight.y = 0;

        Vector3 targetDirection = (cameraForward * verticalInput + cameraRight * horizontalInput).normalized;
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            
            // Now, you can synchronize the rotation over the network using PhotonView.
            // This will send the rotation to other players in the room.
            photonView.RPC("SyncRotation", RpcTarget.All, transform.rotation);
        }
    }

    [PunRPC]
    void SyncRotation(Quaternion newRotation)
    {
        // Set the received rotation on all clients' instances of the player.
        transform.rotation = newRotation;
    }
}
