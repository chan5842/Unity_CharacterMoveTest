using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeForm : MonoBehaviour
{
    public enum FormType
    {
        FOX,
        TIGER,
        EAGLE
    }
    public FormType curForm = FormType.FOX; // ���� ��(����Ʈ �� : ����)

    public Sprite[] FormIcons;  // �� ��������Ʈ ������(����, ȣ����, ������)
    public Image FormImage;     // UI�� ǥ�õ� �̹���(�� ��ȯ�� ����)
    public MeshRenderer Staff;  // ������ �� �޽� ������
    
    public bool canFormChange = true;      // �� ��ȯ ���� ����
    public float charForm_CoolTime = 7.0f;  // �� ��ȯ ��Ÿ��
    public float charForm_Timer;


    void Update()
    {
        FormChange();
    }


    void ChangeFormSprite()
    {
        FormImage.sprite = FormIcons[(int)curForm];
    }
    void FormChange()
    {
        // ����� ����1�� ������ ���� ������ ��ȯ
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (curForm == FormType.FOX) return;
            if (canFormChange)
            {
                /* 
                * �� ��ȯ �ִϸ��̼��̳� ��ƼŬ �־��ֱ�
                */
                Staff.enabled = true;   // ���� ���϶��� �����̸� ���
                /*
                 * �ٸ� ������ ���⸦ ����Ѵٸ� �ڵ� �߰�
                */
                curForm = FormType.FOX;

                ChangeFormSprite();
                /*
                 * UI ���� ��Ÿ�� ���� ��� ����
                 * ���� : https://rito15.github.io/posts/unity-memo-cooldown-icon-ui/
                */
            }
            canFormChange = false;
        }

        // ����� ����2�� ������ ȣ���� ������ ��ȯ
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (canFormChange)
            {
                /* 
               * �� ��ȯ �ִϸ��̼��̳� ��ƼŬ �־��ֱ�
               */
                Staff.enabled = false;   // ȣ���� ���϶��� �����̸� ���X
                /*
                 * �ٸ� ������ ���⸦ ����Ѵٸ� �ڵ� �߰�
                */
                curForm = FormType.TIGER;
                ChangeFormSprite();
            }
            canFormChange = false;
        }
        // ����� ����3�� ������ ������ ������ ��ȯ
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (canFormChange)
            {
                /* 
             * �� ��ȯ �ִϸ��̼��̳� ��ƼŬ �־��ֱ�
             */
                Staff.enabled = false;   // ������ ���϶��� �����̸� ���X
                /*
                 * �ٸ� ������ ���⸦ ����Ѵٸ� �ڵ� �߰�
                */
                curForm = FormType.EAGLE;
                ChangeFormSprite();
            }
            canFormChange = false;

        }
        CoolDown();
    }

    private void CoolDown()
    {
        if (!canFormChange)
        {
            charForm_Timer += Time.deltaTime;
            if (charForm_Timer > charForm_CoolTime)
            {
                charForm_Timer = 0;
                canFormChange = true;
            }
        }
    }
}
