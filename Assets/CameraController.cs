using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public float lookSpeed = 3;
    public float moveSpeed = 5;

    void Update()
    {
        if (Input.GetKey("q"))
        {
            moveSpeed -= 5;
        }
        if (Input.GetKey("e"))
        {
            moveSpeed += 5;
        }
        if (Input.GetKey("w"))
        {
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("a"))
        {
            transform.position += -transform.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("s"))
        {
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey("d"))
        {
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        }
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * lookSpeed;
    }
}
