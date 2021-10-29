using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLockon : MonoBehaviour
{
    public float torque = 500f;
    public float thrust = 1000f;
    private Rigidbody rb;
    public Transform target;
    public Transform selfTransform;
    public float damping = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("TargetPlayer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            //make the enemy look smoothly when changing directions
            Quaternion rotation = Quaternion.LookRotation(target.position - selfTransform.position);
            selfTransform.rotation = Quaternion.Slerp(selfTransform.rotation, rotation, Time.deltaTime * damping);

            //moves the enemy towards the player and slows down a little when it gets close
            Vector3 targetLocation = target.position - transform.position;
            float distance = targetLocation.magnitude;
            rb.AddRelativeForce(Vector3.forward * Mathf.Clamp((distance - 10) / 50, 0f, 1f) * thrust * 2);

            //i want this to make the enemy ships continue moving when the player dies but it doesnt work.
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("WayBehind").transform;
            }
        }
         

    }



    private void OnTriggerEnter(Collider other)
    {   //this destroys the enemy ship with a big collider once it passes the player
        if (other.tag == "Behind")
        {
            Destroy(gameObject);


        }

        //this makes the enemy ships stop targeting the player when they get too close, and instead target a gameobject behind the player
        if (other.tag == "TooClose")
        {
            target = GameObject.FindGameObjectWithTag("WayBehind").transform;


        }
    }
}
