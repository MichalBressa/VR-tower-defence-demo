using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Turret : MonoBehaviour
{

    // targeting
    public Transform target;
    public float range = 15f;
    private GameObject[] enemiesArray;
    public Transform rotationPart;
    Vector3 rotationDirection;
    Quaternion turretRotation;
    public LayerMask enemyMask;

    public int price;

    //shooting
    public float fireRate = 1f;
    private float fireCountown = 0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawnTransform;
    public GameObject audioObj;

    public Spawner spawner;
    Rigidbody rb;

    public XRGrabInteractable xrGrab;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.useGravity = false;
        //rb.isKinematic = false;
        xrGrab = GetComponent<XRGrabInteractable>();
        Debug.Log(xrGrab);

    }

    public void RespwnTurret()
    {
        Spawner.instanceSpwn.SpawnTheThing();
    }


    public void SetGravityOn()
    {
        
        //rb.isKinematic = false;
        rb.useGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= 0.1f || transform.position.y >= 2f)   
        // if player will drop turret it will be destroyed
        // picking turret is free so it's not gonna cost him anything
        {
            RespwnTurret();
            Destroy(gameObject);
           // spawner.RespawnTurret();
          //  Debug.Log("respawn turret)");
        }

        GetClosestEnemy(GameObject.FindGameObjectsWithTag("Enemy"));

        if (target == null)
        {
            return;
        }
        else
        {
            rotationDirection = target.position - transform.position;
            turretRotation = Quaternion.LookRotation(rotationDirection);
            Vector3 rotation = Quaternion.Lerp(rotationPart.rotation, turretRotation, Time.deltaTime * 8f).eulerAngles;
            rotationPart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

            if (fireCountown <= 0f)
            {
                shoot();
                fireCountown = 1f / fireRate;
            }

            fireCountown -= Time.deltaTime;

        }
        
        
        if (PlayerStats.money < price)
        {
            xrGrab.enabled = false;
            rb.isKinematic = true;
            rb.useGravity = false;
            rb.angularDrag = 0;
        } 
        else
        {
            xrGrab.enabled = true;
            rb.isKinematic = false;
            rb.useGravity = true;
           rb.angularDrag = 0.05f;
        }

        

        
    }

    private void Awake()
    {
        Debug.Log(xrGrab);
    }


    public void ShopSelectTurret1()
    {
        Shop.Instance.SelectTurret1();
    }
    public void ShopSelectRocketTurret()
    {
        Shop.Instance.SelectRocketTurret();
    }

    void  GetClosestEnemy(GameObject[] enemiesArray)
    {
            Transform closestTarget = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = transform.position;
            foreach (GameObject enemyObj in enemiesArray)
            {
                float dist = Vector3.Distance(enemyObj.transform.position, currentPos);
                if (dist < minDist)
                {
                    closestTarget = enemyObj.transform;
                    minDist = dist;
                }
            }

        if (closestTarget != null && minDist <= range)
        {
            target = closestTarget;

        }
        else
        {
            target = null;
        }


    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    public void shoot()
    {

        GameObject bulletObj = (GameObject)Instantiate(bulletPrefab, bulletSpawnTransform.position, Quaternion.Euler( bulletSpawnTransform.rotation.x, bulletSpawnTransform.rotation.y, 90f));
        if (audioObj != null)
        {
            GameObject Audio = (GameObject)Instantiate(audioObj, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
            Destroy(Audio, 0.5f);
        }
        //GameObject bulletObj = (GameObject)Instantiate(bulletPrefab, bulletSpawnTransform.position, bulletSpawnTransform.rotation);
        BulletTurret bullet = bulletObj.GetComponent<BulletTurret>();

        if (bullet != null)
        {
            bullet.chaseTarget(target);
        }


    }




}
