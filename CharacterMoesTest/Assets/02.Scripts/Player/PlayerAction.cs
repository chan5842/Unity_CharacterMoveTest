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
    [Header("�Ƹ� ����� ���� ������Ʈ")]
    public GameObject[] FoxFires;   // �����ϴ� ����� �迭 
    Animator animator;

    public bool isSkill;
    //float speed = 10f;

    float fireRate = 8f;          // �߻� ��� �ð�
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
