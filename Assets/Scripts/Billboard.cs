using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //Reference to the camera's transform
    public Camera cam;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    //To avoid jitter, use LateUpdate instead of Update
    void LateUpdate()
    {
        //Adjust the camera
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
