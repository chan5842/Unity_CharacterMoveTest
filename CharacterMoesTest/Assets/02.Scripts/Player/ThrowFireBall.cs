using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFireBall : MonoBehaviour
{
    Animator animator;
    AudioSource source;

    public Transform FirePos;              // 여우불이 던져질 최초 위치
    [SerializeField]
    GameObject FireBall;            // 여우불 오브젝트

    readonly string playerTag = "Player";

    float fireRate = 1f;          // 발사 대기 시간
    float nextFire = 0f;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        FireBall = Resources.Load("Magic fire") as GameObject;
        //FirePos = GameObject.FindGameObjectWithTag(playerTag).transform.GetChild(1).GetComponent<Transform>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {

            Fire();
        }
    }

    private void Fire()
    {
        nextFire = Time.time + fireRate;
        GameObject Fire = Instantiate(FireBall, FirePos.position, FirePos.rotation);
        //Fire.GetComponent<Rigidbody>().velocity = Fire.transform.forward * throwPower;
        animator.SetTrigger("Fox_Attack");
    }
}
