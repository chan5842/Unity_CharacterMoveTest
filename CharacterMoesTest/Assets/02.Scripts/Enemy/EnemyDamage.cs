using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer renderer;

    readonly string fireBallTag = "FIREBALL";
    readonly string bulletTag = "BULLET";
    readonly string flyattackTag = "FLYATTACKRANGE";
    public float hp = 0f;
    public float hpMax = 100f;

    PlayerAction playerAction;
    CapsuleCollider capsuleCollider;

    void Start()
    {
        hp = hpMax;
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
        playerAction = GetComponent<PlayerAction>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(fireBallTag))
        {
            renderer.material.color = Color.red;
            rb.AddForce(Vector3.back * 500f);
            hp -= 10f;
            StartCoroutine(ResetColor());
        }
        if (other.CompareTag(bulletTag))
        {
            renderer.material.color = Color.red;
            StartCoroutine(ResetColor());
            BulletAttack();
        }
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        renderer.material.color = Color.white;
    }

    void OnDamage()
    {
        capsuleCollider.enabled = true;
    }

    void BulletAttack()
    {
        hp -= 2f;
    }
    void FlyAttack()
    {
        hp -= 10f;
        capsuleCollider.enabled = false;
        Invoke("OnDamage", 5.0f);
    }
}
