using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    public float moveSpeed = 6f;    // 이동 속도
    public float gravity = -9.8f;   // 중력 가속도
    public float jumpForce = 5f;    // 뛰는 힘
    Vector3 moveDir;                // 이동 방향
    
    CharacterController controller;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(controller.isGrounded == false)
        {
            moveDir.y += gravity * Time.deltaTime;
        }
        controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);   
    }

    public void MoveTo(Vector3 dir)
    {
        moveDir = new Vector3(dir.x, moveDir.y, dir.z);
    }

    public void JumpTo()
    {
        if (controller.isGrounded == true)
        {
            Debug.Log("점프");
            moveDir.y = jumpForce;
        }
    }
}
