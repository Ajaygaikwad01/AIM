using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour {

  //[SerializeField]
  // AudioController pickupitemSound;
  

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Player")
            return;

        PickUp(collider .transform );

      //   pickupitemSound.play();
       
    }

    public virtual void OnPickUP(Transform item)
    {

        print("test");
       
    }


    void PickUp(Transform item)
    {

        OnPickUP(item);
      
    }
}
