using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 1;
    public GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //move the gameplay object (camera and the ship) forward at a certain speed
        transform.Translate(Vector3.back * Time.deltaTime * speed);

        //stop the camera if the player dies
        if (playerShip == null)
        {
            speed = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StopForward")
        {
            speed = 0;

        }
    }
}
