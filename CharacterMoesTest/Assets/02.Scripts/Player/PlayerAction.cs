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
    [Header("아리 여우불 관련 오브젝트")]
    public GameObject[] FoxFires;   // 공전하는 여우불 배열 
    Animator animator;

    public bool isSkill;
    //float speed = 10f;

    float fireRate = 8f;          // 발사 대기 시간
    float nextFire = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isSkill) return;

        if (Input.GetMouseButtonDown(1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (GameObject fire in FoxFires)
            {
                fire.SetActive(true);
                animator.SetTrigger("Fox_FireGuard");
                isSkill = true;
            }
        }

        //if(T)
        //{
        //    isSkill = false;
        //}
    }
    

}
