using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(PathFinder))]
//[RequireComponent(typeof(EnemyPlayer ))]
public class EnemyAnamation : MonoBehaviour {


    [SerializeField]
    Animator animator;

    Vector3 lastposition;
    EnemyPlayer enemyPlayer;

    PathFinder pathfinder;
	// Use this for initialization
	void Awake () {
		//pathfinder = GetComponent <PathFinder >();
        enemyPlayer = GetComponent<EnemyPlayer>();
       // enemyPlayer.OnTargetSelected += enemyPlayer_OnTargetSelected;
	}

  
	// Update is called once per frame
    void Update()
    {
            float velocity = ((transform.position - lastposition).magnitude) / Time.deltaTime;
            lastposition = transform.position;
        
            animator.SetBool("IsWalking", enemyPlayer.EnemyState.CurrentMode == EnemyState.Emode.AWARE);
            animator.SetFloat("Vertical", velocity); // pathfinder.Agent.speed);
        
    }
}
