using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform taget;
    public Vector3 offset;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = taget.position + offset;
    }
}
