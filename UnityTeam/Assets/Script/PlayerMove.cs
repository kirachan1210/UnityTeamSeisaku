using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float dashSpeed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        if (Input.GetKey(KeyCode.W))
        {
            pos.x = walkSpeed * Mathf.Cos(rot.x);
            pos.z = walkSpeed * Mathf.Sin(rot.z);
            pos.y = 0.0f;
        }
        else
        {
            pos.x = 0.0f;
            pos.z = 0.0f;
            pos.y = 0.0f;
        }

        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = new Vector3(pos.x, pos.y, pos.z);
        rb.AddForce(force, ForceMode.Force);
//        rb.velocity = pos;
//        GetComponent<Rigidbody>().AddForce(pos);
    }
}
