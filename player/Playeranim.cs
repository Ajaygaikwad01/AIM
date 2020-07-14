using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playeranim : WeaponController {

    private Animator animator;

    //WeaponReloader reloader;

    private PlayerAim m_playeraim;
    private PlayerAim playeraim
    {

        get
        {

            if (m_playeraim == null)
                m_playeraim = GameManager.Instance.localplayer.playerraim;
            return m_playeraim;

        }
    }
    void Start()
    {
       //reloader =GetComponent <WeaponReloader >();
    }
   
 
	void Awake () {
        
        animator = GetComponentInChildren <Animator >();
	}
	
	// Update is called once per frame
	void Update () {

        if (GameManager.Instance.playerIsPaused)
            return;

        animator.SetFloat("Vertical", GameManager.Instance.Inputcontroller.Vertical);
        animator.SetFloat("Horizontal", GameManager.Instance.Inputcontroller.Horizontal);

        animator.SetBool("IsWalking",GameManager .Instance .Inputcontroller .iswalking );
        animator.SetBool("IsSprinting", GameManager.Instance.Inputcontroller.issprinting);
         animator.SetBool("IsCrouch", GameManager.Instance.Inputcontroller.iscrouch);

         animator.SetFloat("AimAngle",playeraim .GetAngle ());

         animator.SetBool("reaload", GameManager.Instance.Inputcontroller.Reload );

         animator.SetBool("switch", GameManager.Instance.Inputcontroller.MouseWheelUp);
         animator.SetBool("switch2", GameManager.Instance.Inputcontroller.MouseWheelDown);


         animator.SetBool("fire", GameManager.Instance.Inputcontroller.Fire1);
        
}
}