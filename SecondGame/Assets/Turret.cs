using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    //range
    public float range = 15f;

    //enemy tag
    public string enemyTag = "Enemy";

    //part to rotate - turret
    public Transform partToRotate;

    //speed to turn
    public float turnSpeed = 10f;


	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

    void UpdateTarget ()
    {
        //array to find the enemies attacked and store in this array
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        //store the shortestDistance found
        float shortestDistance = Mathf.Infinity;

        GameObject nearestEnemy = null;

        //loop
        foreach (GameObject enemy in enemies)
        {
            //get distance to enemy and store in distanceToEnemy
            float distanceToEnemy = Vector3.Distance (transform.position, enemy.transform.position);

            //if distance to enemy is the shortest distance found, store this distance in distanceToEnemy, so that the nearest enemy found is the same enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
                
            }
        }

        // check if nearest enemy is not equal to null and shortest distance is within our range
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else { 
            // if out of range, target is empty
            target = null;  
        }
    }
	
	// Update is called once per frame

        // if we do not have a target, do nothing
	void Update () {
        if (target == null)
            return;


        //target lock on
        //vector 3 for 3D (z) dir for direction, get direction
        Vector3 dir = target.position - transform.position;
        //how to rotate / how to turn to look in that direction
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        //to change from quaternion to euler angles
        //lerp : smooth transitions from one point to another(from the current location to the look rotation(new)
        //over time, and quickness is determened by turnSpeed, and finally covnerted into euler angles
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

    // make sure that the rage is only drawn if we have the turret selected
    void OnDrawGizmosSelected ()
    {
        // draw our range in red
        Gizmos.color = Color.red;
        // draw a sphere with the wire parts shown - not filled out
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
