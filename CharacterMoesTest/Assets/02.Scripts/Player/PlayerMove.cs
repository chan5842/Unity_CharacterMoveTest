using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;

    [Header("이동 관련 변수")]
    public float moveSpeed = 6f;         // 플레이어 이동속도
    Vector3 moveVec;
    [SerializeField]
    float InitSpeed = 6f;           // 플레이어 초기 이동속도
    public float turnSpeed = 80f;    // 플레이어 회전 속도
    public bool isWalk;             // 플레이어 달리기 유무
    public float jumpPower = 10f;    // 플레이어 점프에 가해지는 힘

    float h, v, r;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        //moveSpeed = InitSpeed;
    }

    void Update()
    {
        Move();
        Turn();
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");

        moveVec = new Vector3(h, 0, v).normalized;

        if (h != 0 || v != 0)
        {
            transform.position += moveVec * moveSpeed * Time.deltaTime;      // 이동
            animator.SetBool("IsRun", true);

            Walk();
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
        
        transform.Rotate(Vector3.up * r * Time.deltaTime * turnSpeed);
        transform.LookAt(transform.position);
    }

    void Walk()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isWalk = true;
            moveSpeed = 4f;
            animator.SetBool("IsWalk", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            isWalk = false;
            moveSpeed = InitSpeed;
            animator.SetBool("IsWalk", false);
        }
    }

    private void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        Debug.Log("점프");
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
}
