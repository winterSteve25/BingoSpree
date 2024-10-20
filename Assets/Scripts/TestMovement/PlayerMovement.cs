using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigid;
    [SerializeField]
    private float mouseSentivity = 5f;

    [SerializeField]
    float speed = 1;
    [SerializeField]
    [Range(0, 1)]
    float dBasic = 0.5f;
    [SerializeField]
    [Range(0, 1)]
    float dStopping = 0.5f;
    
    Vector3 moveVelocity;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CalMoveVelocity();
    }
    void CalMoveVelocity()
    {
        moveVelocity = rigid.linearVelocity;
        Vector3 moveDir = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        moveDir.Normalize();

        moveVelocity += moveDir * speed;

        float damping;
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) < 0.01f && Mathf.Abs(Input.GetAxisRaw("Vertical")) < 0.01f)
        {
            damping = Mathf.Pow(1f - dStopping, Time.deltaTime * 10f);
        }
        else
        {
            damping = Mathf.Pow(1f - dBasic, Time.deltaTime * 10f);
        }
        moveVelocity = new Vector3(moveVelocity.x * damping, moveVelocity.y, moveVelocity.z * damping);
    }
    void FixedUpdate()
    {
        rigid.linearVelocity = moveVelocity;
    }
}

