using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(player ))]
public class PlayerShoot : WeaponController  {

    bool isplayerAlive;

    void Start()
    {
       
        isplayerAlive = true;
        GetComponent<player>().PlayerHealth.OnDeath += PlayerHealth_OnDeath;

    }

    private void PlayerHealth_OnDeath()
    {

      // isplayerAlive = false;
    }

	void Update () {
        //if (!isplayerAlive)
        //   return;

        if (GameManager.Instance.playerIsPaused)
            return;

        if(GameManager .Instance .Inputcontroller .MouseWheelDown )
            SwitchWeapon (1);
        if (GameManager.Instance.Inputcontroller.MouseWheelUp)
            SwitchWeapon(-1);

        if (GameManager.Instance.localplayer.PlayerState.movestate == PlayerState.Emovestste.SPRINTING)
            return;

        if (!CANFIRE)
            return;

        if (GameManager.Instance.Inputcontroller.Fire1)
        {
            ActiveWeapon.fire();

        }
        if (GameManager.Instance.Inputcontroller.Reload)
        {
            ActiveWeapon.Reload();

        }
	}
}
