using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    Camera camera;
    Vector2 dir = Vector2.zero;
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        dir = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            dir += new Vector2(Mathf.Cos(0 * Mathf.Deg2Rad), 
                Mathf.Sin(0 * Mathf.Deg2Rad));
        }
        if(Input.GetKey(KeyCode.A))
        {
            dir += new Vector2(Mathf.Cos(-90 * Mathf.Deg2Rad),
                Mathf.Sin(-90 * Mathf.Deg2Rad));
        }
        if(Input.GetKey(KeyCode.S))
        {
            dir += new Vector2(Mathf.Cos(180 * Mathf.Deg2Rad),
                Mathf.Sin(180 * Mathf.Deg2Rad));
        }
        if(Input.GetKey(KeyCode.D))
        {
            dir += new Vector2(Mathf.Cos(90 * Mathf.Deg2Rad),
                Mathf.Sin(90 * Mathf.Deg2Rad));
        }

        dir.Normalize();

        if (dir == Vector2.zero)
            return;

        float angle = Vector2.SignedAngle(new Vector2(Mathf.Cos(0 * Mathf.Deg2Rad),
            Mathf.Sin(0 * Mathf.Deg2Rad)), dir);
        Vector3 moveDir = camera.gameObject.GetComponent<CamTest>().cameraDir;
        moveDir.y = 0f;
        moveDir.Normalize();

        float cameraAngle = Vector3.SignedAngle(Vector3.forward, moveDir, Vector3.up);
        transform.rotation = Quaternion.Euler(Vector3.up * (cameraAngle + angle));
        transform.Translate(Vector3.forward * Time.deltaTime * 10f);
    }
}
