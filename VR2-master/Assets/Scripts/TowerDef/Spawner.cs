using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instanceSpwn;

    public GameObject spawnPoint;

    public GameObject turretPrefab;
    public GameObject turretSpawnAwake;
    private float timer;
    bool turretSpawned = false;

    private void Awake()
    {
        // turretSpawnAwake = (GameObject)Instantiate(turretPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

        timer = 5f;

        instanceSpwn = this;
    }

    public void SpawnTheThing()
    {
        turretSpawnAwake = (GameObject)Instantiate(turretPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    public void SpawnTimerSet()
    {
        timer = 3f;
        turretSpawned = false;
    }

    private void Update()
    {
        if (timer <= 0 && turretSpawned == false) {
            SpawnTheThing();
            turretSpawned = true;
        }


        timer -= Time.deltaTime;
    }

    public void RespawnTurret()
    {
        timer = 5f;

        if(timer <= 0)
        {
            GameObject turretSpawn = (GameObject)Instantiate(turretPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);

        }
    }




}
