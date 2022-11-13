using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFireBall : MonoBehaviour
{
    Animator animator;
    AudioSource source;

    public Transform FirePos;              // ������� ������ ���� ��ġ
    [SerializeField]
    GameObject FireBall;            // ����� ������Ʈ

    public float throwPower = 800f; // ������� �������� ��

    readonly string playerTag = "Player";

    float fireRate = 0.5f;          // �߻� ��� �ð�
    float nextFire = 0f;
   
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
        animator.SetTrigger("Throw");
    }
}
