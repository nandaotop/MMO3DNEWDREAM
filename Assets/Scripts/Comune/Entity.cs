using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public abstract class Entity : MonoBehaviourPun
{
    public AnimatorSync sync;
    public Rigidbody rb;
    public float moveSpeed = 5;
    public float moveMultipler = 100;
    public float rotationSpeed = 10f;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (photonView.IsMine == false) return;

        Tick();
    }

    public virtual void Init()
    {
        sync = GetComponentInChildren<AnimatorSync>();
        sync.Init();
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Tick()
    {

    }
}
