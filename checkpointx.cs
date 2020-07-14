using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointx : MonoBehaviour
{
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
      gm=GameObject .FindGameObjectWithTag("GM").GetComponent<GameMaster >();  
    }

    void OnTriggerEnter(Collider other)
    {
        if(other .CompareTag ("Player"))
        {
            gm.lastcheckpointpos = transform.position;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
