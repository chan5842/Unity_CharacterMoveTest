using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Velocity;
    [Space]

    public float InputX;
    public float InputZ;
    public Vector3 MoveDir;
    public bool blockRotationPlayer;
    public float RotationSpeed = 0.1f;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    public float verticalVel;
    Vector3 moveVector;

    [SerializeField]
    Animator animator;
    [SerializeField]
    CharacterController controller;

    void Start()
    {
        animator = GetComponent<Animator>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        InputMagnitude();

        isGrounded = controller.isGrounded;
        if(isGrounded)
        {
            verticalVel -= 0;
        }
        else
        {
            verticalVel -= 1;
        }
        moveVector = new Vector3(0, verticalVel * 0.2f * Time.deltaTime, 0);
        controller.Move(moveVector);
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camera = cam;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        MoveDir = forward * InputZ + right * InputX;

        if(blockRotationPlayer ==false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(MoveDir), RotationSpeed);
            controller.Move(MoveDir * Time.deltaTime * Velocity);
        }
    }

    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(pos), RotationSpeed);
    }

    public void RotateToCamera(Transform t)
    {
        var camera = cam;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        MoveDir = forward;

        t.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(MoveDir), RotationSpeed);
    }
    void InputMagnitude()
    {
        //Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        //Physically move player

        if (Speed > allowPlayerRotation)
        {
            //animator.SetFloat("Blend", Speed, StartAnimTime, Time.deltaTime);
            animator.SetBool("IsRun", true);
            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            animator.SetBool("IsRun", true);
            //animator.SetFloat("Blend", Speed, StopAnimTime, Time.deltaTime);
        }
        if(Speed == 0f)
            animator.SetBool("IsRun", false);
    }
}
