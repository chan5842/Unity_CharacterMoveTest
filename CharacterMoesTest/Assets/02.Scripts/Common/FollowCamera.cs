using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    
    Transform tr;

    public Vector3 Offset = new Vector3(0f, 5f, -5f);

    void Start()
    {
        tr = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
        tr.position = target.position + Offset;
    }
}
