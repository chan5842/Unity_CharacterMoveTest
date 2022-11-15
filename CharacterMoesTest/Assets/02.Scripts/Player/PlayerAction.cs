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

    public bool canSkill;           // ��ų ��� ���� ���� ����
    //float speed = 10f;

    float skill1_CoolTime = 10f;
    float skill_CoolTimer;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(canSkill)
            {
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
    void CoolDown()
    {
        if(!canSkill)
        {
            skill1_CoolTime += Time.deltaTime;
            //if(skill_CoolTimer)
        }
    }
    

}
