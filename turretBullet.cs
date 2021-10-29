using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour
{
    public GameObject bullet;
    public float speed = 8f;
    public float lifeDuration = 2f;
    public ParticleSystem dieEffectsPrefab;

    public AudioClip turretSound;
    public AudioClip deathSound;

    private float lifeTimer;

    private Rigidbody rb;
    public float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
        AudioSource.PlayClipAtPoint(turretSound, this.gameObject.transform.position);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //make the bullet move
        bullet.transform.position += (bullet.transform.forward * -1) * speed * Time.deltaTime;

        //check bullet
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    
    //destroy the player and bullet if it hits, play sound and effects
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            Instantiate(dieEffectsPrefab, transform.position, transform.rotation);
            lifeTimer = 0f;
            
        }
    }
}
