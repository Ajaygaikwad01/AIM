using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster inst;
    public Vector3 lastcheckpointpos;
    // Start is called before the first frame update
    void Awake()
    {
        if (inst == null)
        {
            inst = this;
            DontDestroyOnLoad(inst);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
