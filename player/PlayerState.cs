using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    public enum Emovestste
    {

        WALKING,
        RUNNING,
        CROUCHING,
        SPRINTING

    }
    public enum EWeponstate
    {
IDLE,
        FIRING,
        AIMING,
        AIMEDFIRING

    }
    public Emovestste movestate;
    public EWeponstate weaponstate;

    private InputController m_inputcontroller;
    public InputController inputcontroller
    {
        get
        {
            if (m_inputcontroller == null)
                m_inputcontroller = GameManager.Instance.Inputcontroller;
            return m_inputcontroller;

        }


    }
    void Update()
    {
        SetMoveState();
        SetWeaponState();
    }


    void SetWeaponState()
    {
        weaponstate = EWeponstate.IDLE;
        if (inputcontroller.Fire1)
            weaponstate = EWeponstate.FIRING;

        if (inputcontroller.Fire2)
            weaponstate = EWeponstate.AIMING ;

        if (inputcontroller.Fire1 && inputcontroller .Fire2)
            weaponstate = EWeponstate.AIMEDFIRING ;
    }

    void SetMoveState()
    {
        movestate = Emovestste.RUNNING;

        if (inputcontroller.issprinting)
            movestate = Emovestste.SPRINTING;

        if (inputcontroller.iswalking )
            movestate = Emovestste.WALKING ;

        if (inputcontroller.iscrouch )
            movestate = Emovestste.CROUCHING ;


    }

}