using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halth : Destructable
{
    [SerializeField]
    float insecond;
    public override void Die()
    {
        base.Die();
        print("died");

        GameManager.Instance.Respawner.Despwan(gameObject, insecond);


    }
    void OnEnable()
    {
        Reset();


    }


    public override void Takedamage(float amount)
    {
        print("remaining:" + Hitpointremaining );
        base.Takedamage(amount);
    }
	}
