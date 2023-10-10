using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 0.2f;

    private Transform target;
    private int waypointIndex = 0;
    public int health = 60;
    public int moneyOnDeath = 20;
    public Camera camera;
    public Slider healthBar;

    public GameObject reachEndSound;

    private void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        target = Waypoint.waypoints[0];
        camera = Camera.main;
    }

    private void Update()
    {
    
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, target.position)<= 0.01f)
        {
            CheckWayPointIndex();
        }

        healthBar.value = health;
        healthBar.transform.LookAt(transform.position + camera.transform.rotation * Vector3.back, camera.transform.rotation * Vector3.up);

    }

    void CheckWayPointIndex()
    {
        if (waypointIndex >= Waypoint.waypoints.Length -1)
        {
            EndReached();
            return;
        }
        waypointIndex++;
        target = Waypoint.waypoints[waypointIndex];


    }


    public void EndReached()
    {
        GameObject Audio = (GameObject)Instantiate(reachEndSound, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(Audio, 1f);

        Destroy(gameObject);

        PlayerStats.lives -= 1;

        if (PlayerStats.lives <= 0)
        {
            PlayerStats.PlayerDead();
        }


        // send haptic feedback
    }

    public void TakeDamage (int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
            PlayerStats.money += moneyOnDeath;
        }
    }

}
