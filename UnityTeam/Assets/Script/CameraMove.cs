using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Vector3 Offset = new Vector3();
    public float RotSpeedX = 1.0f;
    public float RotSpeedY = 0.5f;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float axisX = Input.GetAxis("Mouse X");
        float axisY = Input.GetAxis("Mouse Y");

        transform.RotateAround(player.transform.position, Vector3.up, axisX * RotSpeedX);

        float angle = transform.eulerAngles.x + axisY * RotSpeedY;
        if (angle < 45.0f || 315.0f < angle)
        {
            transform.RotateAround(
                player.transform.position,
                transform.right,
                axisY * RotSpeedY);
        }

        Vector3 position = new Vector3();
        position = player.transform.position;

        position.y += Offset.y;

        position += transform.forward * Offset.z;
        transform.position = position;
    }
}
