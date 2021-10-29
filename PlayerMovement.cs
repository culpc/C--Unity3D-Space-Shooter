using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //parameters
    public float xySpeed = 18;
    public float lookSpeed = 340;
    public float forwardSpeed = 6;

    public AudioClip deathSound;
    public ParticleSystem dieEffectsPrefab;


    private Transform playerModel;


    
    //public refs
    public Transform aimTarget;
    public Transform cameraParent;

    // Start is called before the first frame update
    void Start()
    {
        playerModel = transform.GetChild(0-4);
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");

        LocalMove(h, v, xySpeed);
        RotationLook(h, v, lookSpeed);
        HorizontalLean(playerModel, h, 80, .1f);



    }

    //movement
    void LocalMove(float x, float y, float speed)
    {
        transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
        ClampPosition();
    }

    //prevent player going off screen  
    void ClampPosition()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }

    void RotationLook(float h, float v, float speed)
    {
        aimTarget.parent.position = Vector3.zero;
        aimTarget.localPosition = new Vector3(h, v, 1);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(aimTarget.position), Mathf.Deg2Rad * 5000 * Time.deltaTime);
    }
    void HorizontalLean(Transform target, float axis, float leanLimit, float lerpTime)
    {
        Vector3 targetEulerAngels = target.localEulerAngles;
        target.localEulerAngles = new Vector3(targetEulerAngels.x, targetEulerAngels.y, Mathf.LerpAngle(targetEulerAngels.z, -axis * leanLimit, lerpTime));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(aimTarget.position, .5f);
        Gizmos.DrawSphere(aimTarget.position, .15f);

    }

    //instantiates sounds and effects when the player hits things, and kills the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Map")
        {
            
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            Instantiate(dieEffectsPrefab, transform.position, transform.rotation);

        }

        if (other.tag == "Destroyable")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            Instantiate(dieEffectsPrefab, transform.position, transform.rotation);

        }

        if (other.tag == "Firewall")
        {
            
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            Instantiate(dieEffectsPrefab, transform.position, transform.rotation);

        }
    }
}
