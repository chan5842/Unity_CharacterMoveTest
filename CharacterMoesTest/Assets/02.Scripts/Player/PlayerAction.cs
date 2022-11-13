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

    public bool isSkill;
    float speed = 10f;

    float fireRate = 1.5f;          // �߻� ��� �ð�
    float nextFire = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        // ���콺 ������ ��ư�� ������ ��ų�� Ȱ��ȭ
        if (Input.GetMouseButtonDown(1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (GameObject fire in FoxFires)
            {
                fire.SetActive(true);
                isSkill = true;
            }
        }
    }
    

}
