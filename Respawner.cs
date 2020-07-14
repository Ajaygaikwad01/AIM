using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{


    public void Despwan(GameObject go, float insecond)
    {
        go.SetActive(false);
        GameManager.Instance.Timer.Add(() =>
        {
         
                go.SetActive(true);
            
        }, insecond);

    }

}