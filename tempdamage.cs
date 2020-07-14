using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (Rigidbody ))]
public class tempdamage : MonoBehaviour
{

    

    [SerializeField]
    float damage;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    void OnTriggerEnter(Collider other)
    {
        
        var destructable =other .transform .GetComponent <Destructable>();
        if(destructable ==null)
            return ;

        destructable.Takedamage(damage);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
