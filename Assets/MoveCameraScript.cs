using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedH = 5.0f;
    public float speedV = 5.0f;

    public float yaw;
    public float pitch;
    
    void Start()
    {
        pitch = transform.rotation.x;
        yaw = transform.eulerAngles.y;
        Debug.Log(transform.eulerAngles.y);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            yaw += speedH * Input.GetAxis("Mouse X");
            pitch += speedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }


        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log(transform.forward);
            transform.position += transform.forward * 0.07f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log(transform.forward);
            transform.position += transform.forward * -0.07f;
        }

    }
}
