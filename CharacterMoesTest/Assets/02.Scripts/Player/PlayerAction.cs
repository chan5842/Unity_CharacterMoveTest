using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//// [�Ƹ� �����]
// ��ų ���� ĳ���� ������ 3���� ����� ������Ʈ�� Ȱ��ȭ�Ǹ�
// �� ������� ĳ���͸� �߽����� �����Ѵ�.
// ª�� �ð�(�뷫 1~1.5��)�ڿ� �ֺ��� ���� �ִٸ� �ڵ����� �߻�Ǹ�
// �߻�ü�� ���� ����ź ó�� ���� �����Ѵ�
// �̶� ĳ���� �ֺ��� �����ϴ� ������� �߻�ȴ�

public class PlayerAction : MonoBehaviour
{
    ChangeForm Form;
    Animator animator;
    CharacterController controller;

    [Header("����� ������")]
    public Transform FirePos;              // ������� ������ ���� ��ġ
    [SerializeField]
    GameObject FireBall;            // ����� ������Ʈ
    readonly string playerTag = "Player";
    float fireRate = 1f;          // �߻� ��� �ð�
    float nextFire = 0f;

    [Header("����� ����")]
    public GameObject[] FoxFires;   // �����ϴ� ����� �迭 
    public bool canSkill = true;           // ��ų ��� ���� ���� ����
    float skill1_CoolTime = 10f;
    float skill_CoolTimer;

    void Start()
    {
        Form = GetComponent<ChangeForm>();
        controller = GetComponent<CharacterController>();
        FireBall = Resources.Load("Magic fire") as GameObject;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Form.curForm == ChangeForm.FormType.FOX)
        {
            if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
            {
                Fire();
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                if (canSkill)
                {
                    Debug.Log("Hi");
                    foreach (GameObject fire in FoxFires)
                    {
                        fire.SetActive(true);
                        animator.SetTrigger("Fox_FireGuard");
                    }
                }
                canSkill = false;
            }
            CoolDown();
        }
        else if(Form.curForm == ChangeForm.FormType.TIGER)
        {

        }
        else if(Form.curForm == ChangeForm.FormType.EAGLE)
        {

        }
    }

    private void Fire()
    {
        nextFire = Time.time + fireRate;
        GameObject Fire = Instantiate(FireBall, FirePos.position, FirePos.rotation);
        //Fire.GetComponent<Rigidbody>().velocity = Fire.transform.forward * throwPower;
        animator.SetTrigger("Fox_Attack");
    }
    void CoolDown()
    {
        if(!canSkill)
        {
            skill1_CoolTime += Time.deltaTime;
            canSkill = true;
            //if(skill_CoolTimer)
        }
    }

    //void Fly() //���� ���� �Լ�
    //{
    //    if (controller.isGrounded == false)
    //    {
    //        if (Input.GetKeyDown(KeyCode.E) && CanFly && !isFly)
    //        {
    //            rd.drag = 10.0f;
    //            isJump = false;
    //            isFly = true;
    //            CanJump = false;
    //            CanFlyAttack = true;
    //        }
    //        else if (Input.GetKeyDown(KeyCode.E) && CanFly && isFly)
    //        {
    //            rd.drag = 0;
    //            isJump = false;
    //            isFly = false;
    //        }
    //        else if (Input.GetMouseButtonDown(0) && CanFlyAttack && !CanJump)
    //        {
    //            rd.drag = 0;
    //            isFlyAttack = true;
    //            FlyAttackActive();
    //        }
    //    }
    //}

}
