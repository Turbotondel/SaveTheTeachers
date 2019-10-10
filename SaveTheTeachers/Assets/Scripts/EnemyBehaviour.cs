using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public List<Vector3> patrollingWaypoints = new List<Vector3>();
    Vector3 currentDestination;
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        currentDestination = patrollingWaypoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        moveTowardsNextWaypoint();
    }

    void moveTowardsNextWaypoint()
    {
        if (transform.position.Equals(currentDestination))
        {
            int currentItemIndex = patrollingWaypoints.IndexOf(currentDestination);
            //if current destination is the last waypoint in the list, we need to reset to the first waypoint
            if (currentItemIndex == patrollingWaypoints.Count - 1)
            {
                currentDestination = patrollingWaypoints[0];
            }
            else
            {
                currentDestination = patrollingWaypoints[currentItemIndex + 1];
            }
        }
        //Disable next line if navmesh is available
        transform.position = Vector3.MoveTowards(transform.position, currentDestination, speed * Time.deltaTime);
        //Enable next line if navmesh is available
    }
}
