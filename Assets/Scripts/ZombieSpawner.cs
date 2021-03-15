using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    float lastSpawned = 0f;
    public float spawnDelay;

    public GameObject zombiePrefab;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > lastSpawned + spawnDelay)
        {
            SpawnZombie();
            lastSpawned = Time.time;
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombiePrefab, gameObject.transform.position, Quaternion.identity);
        //Debug.Log("Spawned zombie!");
    }
}
