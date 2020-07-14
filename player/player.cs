using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent (typeof(CharacterController  ))]
[RequireComponent(typeof(PlayerState))]
[RequireComponent(typeof(PlayerHealth2 ))]
public class player : MonoBehaviour {

    [System.Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool lockMouse;
    }


    [SerializeField]
    swatSoldier setting;

     [SerializeField ]MouseInput MouseControl;

     [SerializeField]
     AudioController footsteps;
     [SerializeField]
     float minmovethreshold;

     public PlayerAim playerraim;


     Vector3 priviousposition;

     private PlayerHealth2 m_PlayerHealth;
     public PlayerHealth2 PlayerHealth
     {
         get
         {
             if (m_PlayerHealth == null)
                 m_PlayerHealth = GetComponent<PlayerHealth2>();
             return m_PlayerHealth;

         }
     }


     private CharacterController m_movecontriller;
     public CharacterController movecontroller
     {
         get
         {
             if(m_movecontriller  == null)
                 m_movecontriller = GetComponent<CharacterController>();
             return m_movecontriller;

         }



     }
     private Crosshair m_Crosshair;
     public Crosshair crosshair
     {
         get
         {
             if (m_Crosshair == null )
             m_Crosshair = GetComponentInChildren<Crosshair>();
             return m_Crosshair;



         }




     }
     private PlayerState m_PlayerState;
     public PlayerState PlayerState
     {
         get
         {
             if (m_PlayerState == null)
                 m_PlayerState = GetComponentInChildren<PlayerState>();
             return m_PlayerState;
         }

     }

    InputController playerInput;
    Vector2 mouseInput;

   

	void Awake () {
       
        playerInput = GameManager.Instance.Inputcontroller;
        GameManager.Instance.localplayer = this;

        if(MouseControl .lockMouse ){

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
	}


    void Update()
    {

        if(GameManager.Instance .playerIsPaused )
            return;

        // if (!PlayerHealth.Isalive)
        //   return;

        Move();

        lookAround();

    }

    private void lookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);


        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
      //  crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);

        playerraim.SetRotation(mouseInput.y * MouseControl.Sensitivity.y);

    }
    void Move()
    {

        float moveSpeed =setting . runspeed;

        if(playerInput .iswalking )
        {
            moveSpeed =setting. walkspeed; 

        }
        if (playerInput.issprinting)
            moveSpeed = setting.sprintspeed;

        if (playerInput.iscrouch)
            moveSpeed = setting.crouchspeed;

      

        Vector2 direction = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
        movecontroller.SimpleMove (transform.forward * direction.x  + transform.right * direction.y);

        if (Vector3.Distance(transform.position, priviousposition) > minmovethreshold)
        {
            footsteps.play();
        }
        priviousposition = transform.position;

    }
}
