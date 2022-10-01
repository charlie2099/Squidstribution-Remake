using System;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSequence : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypoints;
    //private int _waypointIndex;

    private void OnDrawGizmos()
    {
        /*for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(waypoints[i].transform.position, waypoints[++i].transform.position);
        }*/
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(waypoints[0].transform.position, waypoints[1].transform.position);
        Gizmos.DrawLine(waypoints[1].transform.position, waypoints[2].transform.position);
        Gizmos.DrawLine(waypoints[2].transform.position, waypoints[3].transform.position);
        Gizmos.DrawLine(waypoints[3].transform.position, waypoints[0].transform.position);
    }
}
