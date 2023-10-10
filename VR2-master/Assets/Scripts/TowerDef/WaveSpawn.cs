using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveSpawn : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawn;
    public float timeBetweenWaves = 10f;
    public TextMeshProUGUI textUI;
    private float timer = 15f;

    public GameObject waveAudio;

    public static int waveNumber = 0;

    GameObject[] enemiesAlive;

    // Update is called once per frame
    void Update()
    {
        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemiesAlive.Length <= 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                GameObject Audio = (GameObject)Instantiate(waveAudio, spawn.transform.position, spawn.transform.rotation);
                
                StartCoroutine(spawnWave());
                Debug.Log("All enemies dead");
                timer = timeBetweenWaves;
            }


            textUI.text = Mathf.Round(timer).ToString();

        }
        else
        {
            textUI.text = "Wave " + waveNumber;
        }

       
    }

    IEnumerator spawnWave()
    {
        waveNumber++;
        Debug.Log("Wave incoming");

        for (int i = 0; i < waveNumber * 2; i++)
        {
            
            spawnEnemy();
            yield return new WaitForSeconds(0.5f);
            
        }

    }

    void spawnEnemy()
    {
        Instantiate(enemyPrefab, spawn.position, spawn.rotation);
    }


}
