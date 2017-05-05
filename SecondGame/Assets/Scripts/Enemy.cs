using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

    //speed
    public float speed = 10f;

    // health
    public int health = 100;

    //money
    public int value = 50;
     
    private Transform target;
    private int wavepointIndex = 0;

    void Start ()
    {
        target = Waypoints.points[0];
    }

   // if health is less or equal to 0 die
    public void TakeDamage (int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    //add value to the money and destroy enemy
    void Die ()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Update()
    {
        //dir= direction
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

    }

    void GetNextWaypoint()
    {

        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];

    }

    // if reaches the end, reduce life, destroy enemy
    void EndPath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }

    
}
