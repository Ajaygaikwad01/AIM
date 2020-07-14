using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SHADERS.Extensions;
using UnityEngine.UI;

//[RequireComponent(typeof(EnemyPlayer))]
public class EnemyShoot : WeaponController
{
  

    [SerializeField]
    float ShootingSpeed;

    [SerializeField]
    float BurstDurationMax;

    [SerializeField]
    float BurstDurationMin;


    EnemyPlayer enemyplayer;
    bool shouldFire;

	void Start () {
        enemyplayer = GetComponent<EnemyPlayer>();
        enemyplayer.OnTargetSelected += enemyplayer_OnTargetSelected;
	}

    private void enemyplayer_OnTargetSelected(player target)
    {
        print("OnTargetSelected");
        ActiveWeapon.AimTarget = target.transform;
        ActiveWeapon.AimTargetOffSet = Vector3.up * 1f;
        StartBurst();
       

    }

    void StartBurst()
    {
        if (!enemyplayer.EnemyHelth.Isalive)
            return;
       CheckReload();

       
       

        shouldFire = true;
        GameManager.Instance.Timer.Add(EndBurst,Random .Range (BurstDurationMin , BurstDurationMax ) );
      


    }
    void EndBurst()
    {
        shouldFire = false;
        if (!enemyplayer.EnemyHelth.Isalive)
           return;

        CheckReload();

        if (canseetarget())
        {
            GameManager.Instance.Timer.Add(StartBurst, ShootingSpeed);
        }
    }

  bool canseetarget()
    {

       // enemyplayer.ClearTargetAndScan();
       // return false;

         if (!transform.IsLineOfSight(ActiveWeapon.AimTarget.position, 90, enemyplayer.playerscanner.mask, Vector3.up))
          {
            enemyplayer.ClearTargetAndScan();
          return false;
          }
          return true;
    }

    void CheckReload()
    {
        if (ActiveWeapon.reloader.RoundRemainingInClip == 0)
         ActiveWeapon.Reload();
    }
	// Update is called once per frame
    void Update()
    {

        if (GameManager.Instance.playerIsPaused)
            return;


        if (!shouldFire || !CANFIRE  || !enemyplayer.EnemyHelth.Isalive)
          return;

        ActiveWeapon.fire();
    }

}
