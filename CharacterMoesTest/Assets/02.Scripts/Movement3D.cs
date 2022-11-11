using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    public float moveSpeed = 6f;    // �̵� �ӵ�
    public float gravity = -9.8f;   // �߷� ���ӵ�
    public float jumpForce = 5f;    // �ٴ� ��
    Vector3 moveDir;                // �̵� ����
    
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
            Debug.Log("����");
            moveDir.y = jumpForce;
        }
    }
}
