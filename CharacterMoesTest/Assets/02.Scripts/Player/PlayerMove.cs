using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    float h, v, r;
    public float moveSpeed = 5f;
    public float rotSpeed = 80f;
    Transform playerTr;

    readonly int hashWalk = Animator.StringToHash("IsWalk");
    readonly int hashRun = Animator.StringToHash("IsRun");
    

    Vector3 moveVec;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerTr = GetComponent<Transform>();
        
    }


    void Update()
    {
        Move();
        Turn();
        UpdateAnimator();
    }

    private void Turn()
    {
        playerTr.LookAt(transform.position + moveVec);
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        moveVec = new Vector3(h, 0, v).normalized;
        
        playerTr.position += moveVec * moveSpeed * Time.deltaTime;
        playerTr.Rotate(Vector3.up * r * Time.deltaTime * rotSpeed);
    }

    void UpdateAnimator()
    {
        if (h != 0f || v != 0f)
        {
            animator.SetBool(hashWalk, true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool(hashWalk, false);
                animator.SetBool(hashRun, true);
                moveSpeed = 8.5f;
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                animator.SetBool(hashRun, false);
                animator.SetBool(hashWalk, true);
                moveSpeed = 5f;
            }
        }
        else
            animator.SetBool(hashWalk, false);
    }
}
