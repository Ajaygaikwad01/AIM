using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SHADERS.Extensions;


//[RequireComponent (typeof (PathFinder ))]
//[RequireComponent(typeof(EnemyHelth ))]
//[RequireComponent(typeof(EnemyState ))]

public class EnemyPlayer : MonoBehaviour {

   // public GameObject[] ItemDeadState = null;


    bool xyz;

      Transform player;
      Transform enemy; 


        UnityEngine.AI.NavMeshAgent nav;   

  //  [SerializeField]
  //  PathFinder pathfinder;
   
    [SerializeField ]
    swatSoldier setting;

    [SerializeField]
  public  Scanner playerscanner;

    player priorityTarget;
    List<player> myTagets;

    public event System.Action<player> OnTargetSelected;

    private EnemyHelth m_EnemyHelth;
    public EnemyHelth EnemyHelth
    {
        get
        {
        if(m_EnemyHelth ==null )
         m_EnemyHelth = GetComponent <EnemyHelth >();
        return m_EnemyHelth;

        }


    }
    private EnemyState m_EnemyState;
    public EnemyState EnemyState
    {
        get
        {
            if (m_EnemyState == null)
                m_EnemyState = GetComponent<EnemyState>();
            return m_EnemyState;

        }


    }
    void Awake()
    {

            xyz = true;

        // Set up the references.
            enemy = GameObject.FindGameObjectWithTag("enemy").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //  playerHealth = player.GetComponent <PlayerHealth> ();
        //  enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	void Start () {

        
    ///    pathfinder =GetComponent <PathFinder >();
      //  playerscanner = GetComponent<Scanner>();
       // pathfinder.Agent.speed = setting.walkspeed  ;
       playerscanner.OnScanReady += Scanner_OnScanReady;
       Scanner_OnScanReady();

        EnemyHelth.OnDeath += EnemyHelth_OnDeath;

        EnemyState.OnModeChange += EnemyState_OnModeChange;
	}

    private void EnemyState_OnModeChange(EnemyState .Emode state)
    {
      ///  pathfinder.Agent.speed = setting.walkspeed;
     ///   if (state == EnemyState.Emode.UNAWARE)
        ///    pathfinder.Agent.speed = setting.runspeed;

    }

    private void EnemyHelth_OnDeath()
    {

        //Invoke ("ShoWitemOnDead",1f);
       
            xyz = false;
       
    }

 /*   void ShoWitemOnDead()
    {
        foreach (var item in ItemDeadState)
        {
            item.SetActive(true);
        }
        
    }*/

     private void Scanner_OnScanReady()
     {
         if (priorityTarget != null)
             return;

         myTagets = playerscanner.ScanForTargets<player>();


         if (myTagets.Count == 1)
             priorityTarget = myTagets[0];
         else
             selectClosestTarget();

         if (priorityTarget != null)
         {
             xyz = true;
             if (OnTargetSelected != null)
             {
                 this.EnemyState.CurrentMode = EnemyState.Emode.UNAWARE ;

                 OnTargetSelected(priorityTarget);
              
             }

         }
         }

    private void selectClosestTarget()
    {
       
     float ClosestTarget = playerscanner.ScanRange;
       
        foreach (var possibaltarget in myTagets )
        {
            if (Vector3.Distance(transform.position, possibaltarget.transform.position) < ClosestTarget)
                priorityTarget = possibaltarget;
           
        }

    }

	void Update () {

       // if (GameManager.Instance.playerIsPaused)
        {
           
        }

            enemyfollow();

       

      
      if (priorityTarget == null || !EnemyHelth.Isalive)
        {
            return;

        }
        
           
        

        transform.LookAt(priorityTarget.transform.transform.position);
       

	}
    void ckeckCountinuePetol()
    {
        if (priorityTarget != null)
            return;

      ///  pathfinder.Agent.Resume();

    }
    internal void ClearTargetAndScan()
    {
        priorityTarget = null;

        GameManager.Instance.Timer.Add(ckeckCountinuePetol,UnityEngine .Random .Range (12,16));
        Scanner_OnScanReady();

    }
    public void enemyfollow()
    {

        if (xyz == true )
        {
            followtheplayer();
          /// nav.SetDestination(player.position);
        }
        if (xyz == false )
        {
            return;
        }

    }

    public void followtheplayer()
    {
        if (!GameManager.Instance.playerIsPaused)
           nav.SetDestination(player.position);
       if (GameManager.Instance.playerIsPaused)
           nav.SetDestination(enemy.position);  

    }

}
