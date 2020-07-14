using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;


public class PLAYERPOS : MonoBehaviour
{
    EnemyPlayer enemyplayer;
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastcheckpointpos;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (!enemyplayer.EnemyHelth.Isalive )
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex );
            SpawnAtNewSpawnpoint();
        }
    }
    void SpawnAtNewSpawnpoint()
    {
        //int spawnindex = 1;
        transform.position = gm.transform.position;
        transform.rotation = gm.transform.rotation;
    }
}
