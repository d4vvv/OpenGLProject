using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedH = 5.0f;
    public float speedV = 5.0f;

    public float yaw = 0f;
    public float pitch = 0f;
    
    void Start()
    {
        
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
