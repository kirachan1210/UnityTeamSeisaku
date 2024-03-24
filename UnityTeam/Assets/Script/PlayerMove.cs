using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walkSpeed = 1.0f;
    public float dashSpeed = 2.0f;

    GameObject camera;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Cursor.visible = !Cursor.visible;
        }
        Vector3 velocity = new Vector3();

        if (Input.GetKey(KeyCode.W))
        {
            velocity.z = walkSpeed;
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                velocity.z = dashSpeed;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            velocity.z = 0.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity.x = -walkSpeed;
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                velocity.x = -dashSpeed;
            }
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            velocity.x = 0.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            velocity.z = -walkSpeed;
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                velocity.z = -dashSpeed;
            }
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            velocity.z = 0.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity.x = walkSpeed;
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                velocity.x = dashSpeed;
            }
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            velocity.x = 0.0f;
        }

        Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;

        forward.y = 0.0f;
        right.y = 0.0f;

        forward.Normalize();
        right.Normalize();

        Vector3 move = forward * velocity.z + right * velocity.x;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(move);

        Animator anime = GetComponent<Animator>();
        if(move.magnitude > 0.0f) 
        {
            anime.SetBool("IsRun", true);
            if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            {
                anime.SetBool("IsDash", true);
                //anime.SetBool("IsRun", false);
            }
        }
        else
        {
            anime.SetBool("IsRun", false);
            anime.SetBool("IsDash", false);
        }

        Vector3 lookPos = transform.position;
        lookPos += move;
        transform.LookAt(lookPos, Vector3.up);

    }
}
