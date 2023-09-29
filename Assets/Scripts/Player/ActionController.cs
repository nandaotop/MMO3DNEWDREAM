using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    float rotSpeed = 2;
    bool autoMove = false;
    [SerializeField] float attackRange = 3;
    [SerializeField] float automoveSpeed = 2;
    Enemy enemyTarget;
    public AnimatorSync sync { get; set; }

    public void Tick(Transform follow, float x, float y)
    {
        if (autoMove == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, follow.rotation, rotSpeed * Time.deltaTime);
        }
        RightClick();
        if (x != 0 || y != 0)
        {
            autoMove = false;
        }

        if (autoMove)
        {
            if (enemyTarget == null)
            {
                autoMove = false;
                return;
            }
            Vector3 enemyPos = enemyTarget.transform.position;
            float dist = Vector3.Distance(transform.position, enemyPos);
            float velocity = 0;
            if (dist > attackRange)
            {
                velocity = 1;
                transform.position = Vector3.MoveTowards(transform.position, enemyPos, 
                    automoveSpeed * Time.deltaTime);
            }
            else
            {
                AutoAttack();
            }
            sync.Move(0, velocity);
            Vector3 look = enemyTarget.transform.position - transform.position;
            look.y = 0;
            Quaternion rot = Quaternion.LookRotation(look);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, automoveSpeed * Time.deltaTime);
        }
    }

    private void AutoAttack()
    {
        
    }

    void RightClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == StaticStrings.enemy)
                {
                    autoMove = true;
                    enemyTarget = hit.transform.GetComponent<Enemy>();
                }
            }
        }
    }
}
