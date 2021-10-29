using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject weapon2Prefab;
    public GameObject shooterObject;
    bool weapon2;

    public AudioSource audioSource;
    public AudioClip laserSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetMouseButtonDown(1))
            {
                GameObject bulletObject = Instantiate(bulletPrefab);
                bulletObject.transform.position = shooterObject.transform.position + shooterObject.transform.forward;
                bulletObject.transform.forward = shooterObject.transform.forward;

            }


            if (Input.GetMouseButtonDown(0))
            {
                GameObject bulletObject = Instantiate(bulletPrefab);
                bulletObject.transform.position = shooterObject.transform.position + shooterObject.transform.forward;
                bulletObject.transform.forward = shooterObject.transform.forward;
                //play the sound
                audioSource.PlayOneShot(laserSound);
            }
        }

        
    }
}
