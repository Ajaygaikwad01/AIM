using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickup : PickupItem
{
    public GameObject tempdamage;

    PlayerHealth2 PLAYERHEALTH;

    [SerializeField]
    float responcetime;

    [SerializeField]
    int amount;

    public void Start()
    {
      
    }
    public void Update()
    {
       
    }  

    public override void OnPickUP(Transform item)
    {
        var playerInventory = item.GetComponentInChildren<Destructable >();
        GameManager.Instance.Respawner.Despwan(gameObject, responcetime);
     item.GetComponent<PlayerHealth2>().Reset();

        Instantiate(tempdamage, transform.position, transform.rotation);
        
    }
}
