using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointController : MonoBehaviour {

    WayPoint[] waypoint;


    int currentWaypointIndex = -1;

    public event System.Action<WayPoint> OnWayPointChanged;

	// Use this for initialization
	void Awake () {

        waypoint = GetWayPoint();
	}
    public void SetNextWayPoint()
    {
        currentWaypointIndex++;

        if (currentWaypointIndex ==  waypoint.Length)
            currentWaypointIndex = 0;

        if (OnWayPointChanged != null)
            OnWayPointChanged(waypoint[currentWaypointIndex]);
    }

    WayPoint[] GetWayPoint()
    {

        return GetComponentsInChildren<WayPoint>();
    }


    void OnDrawGizmos()
    {

        Gizmos.color = Color.blue;

        Vector3 PriviousWayPoint = Vector3.zero;
        foreach (var waypoint in GetWayPoint())
        {
            Vector3 WayPointPosition = waypoint.transform.position;
            Gizmos.DrawWireSphere(WayPointPosition , 0.2f);

            if (PriviousWayPoint != Vector3.zero)
                Gizmos.DrawLine(PriviousWayPoint, WayPointPosition);
               PriviousWayPoint = WayPointPosition;
            
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
