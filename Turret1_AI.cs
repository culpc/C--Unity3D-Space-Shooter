using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1_AI : MonoBehaviour
{

    //its not really an AI

    public GameObject bulletPrefab;
    public GameObject turretObject;
    public float timerSeconds = 3;
    public float waitSeconds = 2;




    // Start is called before the first frame update
    void Start()


    {
        //i'm trying to replicate the simple turrets in Zaxxon that just shoot on a timer
        InvokeRepeating("Shoot", waitSeconds, timerSeconds);

    }

    void Shoot()
    {
        GameObject bulletObject = Instantiate(bulletPrefab);
        bulletObject.transform.position = turretObject.transform.position + (turretObject.transform.forward * 1);
        bulletObject.transform.forward = (turretObject.transform.forward * -1);
    }
    private void OnTriggerEnter(Collider other)
    {
        //turrets stop shooting when the player passes
        if (other.tag == "Behind")
        {
            Destroy(gameObject);




        }


    }
}
