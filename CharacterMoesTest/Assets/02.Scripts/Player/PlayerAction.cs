using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//// [아리 여우불]
// 스킬 사용시 캐릭터 주위에 3개의 여우불 오브젝트가 활성화되며
// 각 여우불은 캐릭터를 중심으로 공전한다.
// 짧은 시간(대략 1~1.5초)뒤에 주변에 적이 있다면 자동으로 발사되며
// 발사체는 적을 유도탄 처럼 따라가 공격한다
// 이때 캐릭터 주변을 공전하는 여우불이 발사된다

public class PlayerAction : MonoBehaviour
{
    ChangeForm Form;
    Animator animator;
    CharacterController controller;

    [Header("여우불 던지기")]
    public Transform FirePos;              // 여우불이 던져질 최초 위치
    [SerializeField]
    GameObject FireBall;            // 여우불 오브젝트
    readonly string playerTag = "Player";
    float fireRate = 1f;          // 발사 대기 시간
    float nextFire = 0f;

    [Header("여우불 가드")]
    public GameObject[] FoxFires;   // 공전하는 여우불 배열 
    public bool canSkill = true;           // 스킬 사용 가능 상태 유무
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

    //void Fly() //비행 관련 함수
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
