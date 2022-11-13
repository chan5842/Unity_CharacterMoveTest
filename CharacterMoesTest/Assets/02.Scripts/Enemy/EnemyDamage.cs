using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    Rigidbody rb;
    MeshRenderer renderer;

    readonly string fireBallTag = "FIREBALL";

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        renderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(fireBallTag))
        {
            renderer.material.color = Color.red;
            //Destroy(other.gameObject);
            rb.AddForce(Vector3.back * 500f);
            StartCoroutine(ResetColor());
        }
    }

    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        renderer.material.color = Color.white;
    }

    //IEnumerator Hit()
    //{
        
    //}
}
