using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBehind : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destroyable")
        {
            Destroy(other.gameObject);

            //play the sound
            //using PlayClipAtPoint because the bullet destroys itself and can't use an audio source on it
            //took a while to figure this out

        }
    }
}
