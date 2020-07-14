using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent (typeof (NavMeshAgent))]
public class PathFinder : MonoBehaviour {

    [HideInInspector ]
    public NavMeshAgent Agent;

    [SerializeField]
    float distanceReaminingTRESHOLD;

    bool m_destinationreached;
    bool destinationreached
    {

        get{ return m_destinationreached ; }
        set{
        m_destinationreached =value;
        if (m_destinationreached)
        {
            if(OnDestinationReached !=null )
            OnDestinationReached();
        }

    }
    }


    public event System.Action OnDestinationReached;

	// Use this for initialization
	void Start () {
		Agent =GetComponent <NavMeshAgent>();
	}

    public void SetTarget(Vector3 target)
    {
       

     //   destinationreached = false;
      //  Agent.SetDestination(target );
        
    }
	// Update is called once per frame
	void Update () {
       // if (GameManager.Instance.playerIsPaused)
           // destinationreached = true;
           

       // if (destinationreached || !Agent .hasPath )
         //   return;

       // if (Agent.remainingDistance < distanceReaminingTRESHOLD )
          //  destinationreached = true;
	}
}
