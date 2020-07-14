using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour {

    [SerializeField]
    Text text;

  //  Container inventory;
   public PlayerShoot playershoot;
    WeaponReloader Reloader;
	void Awake () {
      ///  GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoin;
        onDestroy();
	}
    void onDestroy()
    {
        GameManager.Instance.OnLocalPlayerJoined += HandleOnLocalPlayerJoin;
        playershoot.onweaponswitch += handleonweaponswitch;
       // Reloader.OnammoChanged += handledonammochange;
    }

    void HandleOnLocalPlayerJoin(player player)
    { 
        playershoot = player.GetComponent <PlayerShoot>();

       /// playershoot.onweaponswitch += handleonweaponswitch;


       // Reloader = playershoot.ActiveWeapon.reloader;

        
    //  Reloader.OnammoChanged += handledonammochange;

    }

    void handleonweaponswitch(Shooter activeweapon)
    {
        Reloader = activeweapon.reloader;
       Reloader.OnammoChanged += handledonammochange;
       handledonammochange();

    }
    void handledonammochange()
    {
        int amountInInventory = Reloader.RoundRemainingIninventory;
        int amountinclip = Reloader.RoundRemainingInClip;
        text.text = string.Format("{0}/{1}",amountinclip ,amountInInventory );

    }
}
