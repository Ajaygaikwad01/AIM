using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : PickupItem  {


    [SerializeField]
    EWeaponType weapontype;

    PlayerShoot playershoot;

    [SerializeField]
    float responcetime;

    [SerializeField]
    int amount;

    public void Start()
    {
    }

 

    public override void OnPickUP(Transform item)
    {
      var playerInventory= item .GetComponentInChildren <Container>();
      GameManager.Instance.Respawner.Despwan(gameObject, responcetime);



      playerInventory.Put(weapontype.ToString(), amount);
      item.GetComponent<PlayerShoot>().ActiveWeapon.reloader.HandleOnAmmoChange();
         // PlayerShoot.activeweapon.reloader.HandleOnAmmoChange();
    }
}
