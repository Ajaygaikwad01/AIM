using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menubutton : MonoBehaviour
{

    [SerializeField]
    GameObject EscapeMenuPannel;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void menubutton1()
    {
        EscapeMenuPannel.SetActive(true);
        GameManager.Instance.playerIsPaused = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
