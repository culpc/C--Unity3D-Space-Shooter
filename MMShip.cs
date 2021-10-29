using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MMShip : MonoBehaviour
{
    public float speed = 1;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //move the gameplay object (camera and the ship) forward at a certain speed
        transform.Translate(Vector3.forward * -1 * Time.deltaTime * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Behind")
        {
            Destroy(gameObject);




        }
    }
}
