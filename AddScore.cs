using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int points = 50;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            KeepScore.score += points;

        }
    }
}
