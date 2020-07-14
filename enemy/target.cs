using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{

    public float health = 5f;

    public GameObject destroyedVersion;
    public GameObject pickupammo;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if(health <=0f)
        {
            die();
        }
    }

    void die()
    {
        // Spawn a shattered object
        Instantiate(destroyedVersion, transform.position, transform.rotation);
      
        // Remove the current object
        Destroy(gameObject);
        Instantiate(pickupammo, transform.position, transform.rotation);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
