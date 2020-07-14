using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

   // [SerializeField]
  //  AudioController weaponswitchsound;

 

    [SerializeField]
    float WeaponSwitchTime;

    Shooter[] weapons;

    

    int currentweaponindex;

    [HideInInspector ]
  public bool CANFIRE;
    Transform weaponholdster;

    public event System.Action<Shooter> onweaponswitch;



    Shooter m_Activeweapon;
    public Shooter ActiveWeapon
    {
        get
        {
            return m_Activeweapon;
        }
    }


    void Awake()
    {
        CANFIRE = true;
        weaponholdster = transform.Find("WEAPONS");
        weapons = weaponholdster.GetComponentsInChildren<Shooter>();

        //  DeactivateWeapons();
        if (weapons.Length > 0)
            Eqip(0);
    }

    void DeactivateWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {

            weapons[i].gameObject.SetActive(false);
            weapons[i].transform.SetParent(weaponholdster);
        }

    }

  internal void SwitchWeapon(int direction)
    {
        CANFIRE = false;

     //   weaponswitchsound.play();



        currentweaponindex += direction;
        if (currentweaponindex > weapons.Length - 1)
            currentweaponindex = 0;

        if (currentweaponindex < 0)
            currentweaponindex = weapons.Length - 1;


        GameManager.Instance.Timer.Add(() =>
        {
            Eqip(currentweaponindex);
        }, WeaponSwitchTime);

    }
  internal void Eqip(int index)
    {
        DeactivateWeapons();
        CANFIRE = true;
        m_Activeweapon = weapons[index];
        m_Activeweapon.Eqip();


        weapons[index].gameObject.SetActive(true);
        if (onweaponswitch != null)
            onweaponswitch(m_Activeweapon);
    }
}
