using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event System.Action<player> OnLocalPlayerJoined;
    public GameObject gameObject;

    public bool playerIsPaused { get; set; }

    public static GameManager m_Instance;
    public static GameManager Instance
    {

        get
        {

            if (m_Instance == null)
            {
                m_Instance = new GameManager();
                m_Instance.gameObject = new GameObject("_gameManager");
                m_Instance.gameObject.AddComponent<InputController>();
                m_Instance.gameObject.AddComponent<Timer>();
                m_Instance .gameObject .AddComponent <Respawner>();
               
            }
            return m_Instance;
        }
    
   
    }
    public InputController m_InputController;
    public InputController Inputcontroller
    {
        get
        {
            if (m_InputController == null)
                m_InputController = gameObject.GetComponent<InputController>();
            return m_InputController;

        }
    }
    private Timer m_Timer;
    public Timer Timer
    {
        get
        {
            if(m_Timer ==null)
                m_Timer =gameObject .GetComponent <Timer>();
            return m_Timer;
       }  }

    private eventbus m_eventbus;
    public eventbus eventbus
    {
        get
        {
            if (m_eventbus == null)
                m_eventbus = new eventbus();
            return m_eventbus;
        }
    }

    private Respawner m_Respawner;
    public Respawner Respawner
    {
        get
        {
            if(m_Respawner ==null)
                m_Respawner = gameObject.GetComponent<Respawner>();
            return m_Respawner;

        }

    }


    private player m_Localplayer;
    public player localplayer
    {
        get
        {
            return m_Localplayer;

        }
        set
        {

            m_Localplayer = value;
            if (OnLocalPlayerJoined != null)

                OnLocalPlayerJoined(m_Localplayer );


        }



    }
}


		
	

