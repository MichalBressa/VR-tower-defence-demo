using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTurret : MonoBehaviour
{
    private Transform enemyTarget;

    public GameObject audio; 

    public int damage = 5;

    public float radius = 0f;

    public float speed = 70f;

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = enemyTarget.position - transform.position;

        float overshoot = speed * Time.deltaTime;

        if (direction.magnitude <= overshoot)
        {
            hitTarget();
            return;
        }

        transform.Translate(direction.normalized * overshoot, Space.World);
        //transform.LookAt(enemyTarget);
    }


    public void chaseTarget(Transform target)
    {
        enemyTarget = target;
    }


    public void hitTarget()
    {

        if (radius > 0f)
        {
            Explode();
            GameObject Audio = (GameObject)Instantiate(audio, transform.position, transform.rotation);
            Destroy(Audio, 0.3f);
        }
        else
        {
            Damage(enemyTarget);
            Destroy(gameObject);
        }


    }


    public void Damage(Transform _enemy)
    {
        
        Enemy enemy = _enemy.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        
    }

    public void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider item in colliders)
        {
            if (item.tag == "Enemy")
            {
                Damage(item.transform);
            }
        }
    }

}
