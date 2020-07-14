using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYSPWAN : MonoBehaviour
{
    public GameObject enemy;
    public Transform enemypos;
    private float repaterate = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner",0.5f,repaterate );
            Destroy(gameObject ,11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    void EnemySpawner()
    {
        Instantiate(enemy, enemypos.position, enemypos.rotation);
    }
}
