using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonball : MonoBehaviour
    
    //used my original cannonball script from earlier assignment but changed it A LOT
{
    public GameObject ball;
    public float speed = 8f;
    public float lifeDuration = 2f;
    public ParticleSystem dieEffectsPrefab;
    public ParticleSystem sparkEffectsPrefab;
    public ParticleSystem elecSparkEffectsPrefab;

    public AudioClip destroySound;


    private float lifeTimer;

    private Rigidbody rb;
    public float damage = 0;

    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = lifeDuration;
        
    }

    // Update is called once per frame
    void Update()
    {
    //make the bullet move
    ball.transform.position += (ball.transform.forward*-1) * speed * Time.deltaTime;
        

        //check bullet for lifetime
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroyable")
        {
            Destroy(other.gameObject);
            
            //play the sound
            //using PlayClipAtPoint because the bullet destroys itself and can't use an audio source on it
            //took a while to figure this out
            AudioSource.PlayClipAtPoint(destroySound, this.gameObject.transform.position);

            //play effects
            Instantiate(dieEffectsPrefab, transform.position, transform.rotation);

            //kill the bullet
            lifeTimer = 0f;

            damage += 1;
            Debug.Log("Damage" + damage);

            
        }
        if (other.tag == "Map")
        {
            //play effects
            Instantiate(sparkEffectsPrefab, transform.position, transform.rotation);
            lifeTimer = 0f;
            
            
        }
        if (other.tag == "Firewall")
        {
            Instantiate(elecSparkEffectsPrefab, transform.position, transform.rotation);
            lifeTimer = 0f;
        }
    }
}
