using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponReloader : MonoBehaviour {



    [SerializeField]
    int maxAmmo;
    [SerializeField]
    float reloadtime;
    [SerializeField]
    int clipSize;
    [SerializeField]
    Container Inventory;
    [SerializeField]
    EWeaponType weapontype;

   // int ammo;
   public int shotfiredinclip;
    bool isreloading;
    System .Guid contanoritemid;

    public event System.Action OnammoChanged;

    public int RoundRemainingInClip
    {
        get
        {
            return clipSize - shotfiredinclip;
        }
   }

    public int RoundRemainingIninventory
    {
        get
        {
            return Inventory.GetAmountRemaining(contanoritemid);
        }
    }

    public bool isReloading
    {
        get
        {
            return isreloading;

        }


    }


    void Awake()
    {
        Inventory.OnContanerReady += () =>
        {
            contanoritemid = Inventory.Add(weapontype.ToString(), maxAmmo);
        };

    }
    public void Reload()
    {

        if (isreloading)
            return;
        isreloading = true;

       // int ammountfrominventory = Inventory.TakeFromContainer(contanoritemid, clipSize - RoundRemainingInClip);
      
        print("reaload start");

       
        GameManager.Instance.Timer.Add(() => {


            ExecuteReload (Inventory.TakeFromContainer(contanoritemid, clipSize - RoundRemainingInClip));
        },reloadtime );

        
    }

    private void ExecuteReload(int amount)
    {

        print("reload exicute");
        isreloading = false;

        shotfiredinclip -= amount;
        HandleOnAmmoChange();
       
     
        }
    public void TakeFromClip(int amount)
    {
        shotfiredinclip += amount;

        HandleOnAmmoChange();

    }
    public void HandleOnAmmoChange()
    {
        if (OnammoChanged != null)
            OnammoChanged();
        
    }

    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
