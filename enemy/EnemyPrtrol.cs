using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(PathFinder))]

//[RequireComponent(typeof(EnemyPlayer ))]
public class EnemyPrtrol : MonoBehaviour {


    [SerializeField]
    WayPointController waypointcontroller;


    [SerializeField]
    float waitTimemin;

    [SerializeField]
    float waitTimemax;

   
 ///PathFinder pathfinder;


    ///private EnemyPlayer m_EnemyPlayer;
    /// public EnemyPlayer EnemyPlayer
    /// {
      ///   get
       ///  {
         ///    if (m_EnemyPlayer == null)
         ///        m_EnemyPlayer = GetComponent<EnemyPlayer>();
          ///   return m_EnemyPlayer;

        /// }
    /// }
	// Use this for initialization
	void Start () {

        ///waypointcontroller.SetNextWayPoint();

	}

    void Awake()
    {
///pathfinder = GetComponent <PathFinder >();
///pathfinder.OnDestinationReached += PathFinder_OnDestinationReached;
//waypointcontroller.OnWayPointChanged += waypointcontroller_OnWayPointChanged;

///EnemyPlayer.EnemyHelth.OnDeath += EnemyHelth_OnDeath;
///EnemyPlayer.OnTargetSelected +=EnemyPlayer_OnTargetSelected;
    }
    private void EnemyPlayer_OnTargetSelected(player obj)
    {

     ///   pathfinder.Agent.Stop();
    }

   private void EnemyHelth_OnDeath()
    {
      ///  pathfinder.Agent.Stop();

    }
    private void waypointcontroller_OnWayPointChanged(WayPoint waypoint)
    {

      ///  pathfinder.SetTarget(waypoint .transform .position );

    }
    private void PathFinder_OnDestinationReached()
    {
     
        // StartCoroutine(setnextwaypointAfterTime(Random.Range(waitTimemin, waitTimemax)));
       
        
        ///GameManager.Instance.Timer.Add(waypointcontroller.SetNextWayPoint , Random .Range (waitTimemin ,waitTimemax ));
    }

   /* IEnumerator  setnextwaypointAfterTime(float time)
    {
        yield return new WaitForSeconds(time );
        waypointcontroller.SetNextWayPoint();

    }*/
	// Update is called once per frame
	void Update () {
       
	}
}
