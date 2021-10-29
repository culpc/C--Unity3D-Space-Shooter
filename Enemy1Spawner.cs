using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject Enemy;
    private int x;
    private int z;
    private int count;

    public int xRangeStart;
    public int xRangeEnd;
    public int zRangeStart;
    public int zRangeEnd;
    public int y;
    public int spawnnumber = 5;
    public float waitBetweenSpawns = 1f;

    
    //void Start()
    //{
    //    StartCoroutine(EnemyDrop());
    //}

    IEnumerator EnemyDrop()
    {
        while (count < spawnnumber)
        {
            x = Random.Range(xRangeStart, xRangeEnd);
            z = Random.Range(zRangeStart, zRangeEnd);
            Instantiate(Enemy, new Vector3(x, y, z), Quaternion.identity);
            yield return new WaitForSeconds(waitBetweenSpawns);
            count += 1;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(EnemyDrop());

        }
    }
}
