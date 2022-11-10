using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTest : MonoBehaviour
{
    public GameObject target = null;
    public float fdelta = -5f;
    public Vector3 cameraDir = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.LookAt(target.transform);
        cameraDir = target.transform.position - transform.position;
        cameraDir.Normalize();
        transform.position = target.transform.position + fdelta * cameraDir;
        Vector3 v = transform.position;
        v.y = target.transform.position.y + 2f;
        transform.position = v;
    }
}
