using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof (Collider ))]
public class Destructable : MonoBehaviour
{
    [SerializeField]
    float hitpoint;
    public event System.Action OnDeath;
    public event System.Action OnDamageReceived;
    float damagetaken;

    public float Hitpointremaining
    {
        get
        {
            return hitpoint - damagetaken;
        }
    }
    public bool Isalive
    {
        get
        {
            return Hitpointremaining > 0;
        }
    }
    public virtual void Die()
    {
      //  if (Isalive)
        //    return;
        if (OnDeath != null)
            OnDeath();
    }

    public virtual void Takedamage(float amount)
    {
        damagetaken += amount;

        if (OnDamageReceived != null)
            OnDamageReceived();

        if (Hitpointremaining <= 0)
        {
            Die();
        }
    }

    public void Reset()
    {
        damagetaken = 0;
    }
    
}
