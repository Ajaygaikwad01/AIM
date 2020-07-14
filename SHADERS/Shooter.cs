using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField] float rateoffire;
   
    [SerializeField]
    projectile Projectile;
    [SerializeField]
    Transform hand;
    [SerializeField]
    AudioController audioReload;
    [SerializeField]
    AudioController audioFire;
    
   public Transform AimTarget;
   public Vector3 AimTargetOffSet;

    [HideInInspector ]
     public Transform muzzle;
  public WeaponReloader reloader;
  private ParticleSystem muzzleFirePartical;

  Weaponrecoil m_Weaponrecoil;
  Weaponrecoil Weaponrecoil
  {
      get
      {
          if (m_Weaponrecoil == null)
              m_Weaponrecoil = GetComponent<Weaponrecoil>();

          return m_Weaponrecoil;

      }

  }


    float nextFireAllowed;
	
    public void Reload (){

        if (reloader == null)
            return;
    reloader.Reload();

    audioReload.play();
    }

    public bool canfire;

  public void Eqip()
    {

        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
  


    void Awake () {



        muzzle = transform.Find("Model/Muzzle");

        reloader = GetComponent <WeaponReloader >();
    muzzleFirePartical = muzzle .GetComponent <ParticleSystem >();
        

	}

    void FireEffect()
    {

        if (muzzleFirePartical == null)
            return;
        muzzleFirePartical.Play();

    }


    public virtual void fire()
    {
           canfire = false;
        if (Time.time < nextFireAllowed)
            return;

        if(reloader !=null){
            if (reloader.isReloading)
                return;

            if (reloader.RoundRemainingInClip == 0)
                return;

            reloader.TakeFromClip(1);

        }

        nextFireAllowed = Time.time + rateoffire;

        bool islocalPlayerControllrd = AimTarget == null;

        if ( ! islocalPlayerControllrd)
   muzzle.LookAt(AimTarget.position + AimTargetOffSet );
      

       projectile newbullet= (projectile ) Instantiate(Projectile ,muzzle.position ,muzzle.rotation );

       if (islocalPlayerControllrd)
       {
           Ray ray = Camera.main.ViewportPointToRay(new Vector3 (.5f,.5f,0));
          
           RaycastHit hit;
           Vector3 targetPosition = ray.GetPoint(500);

           if (Physics.Raycast(ray, out hit))
               targetPosition = hit.point;

           newbullet.transform.LookAt(targetPosition + AimTargetOffSet );

       }
       if (this.Weaponrecoil)
           this.Weaponrecoil.Activate();

       FireEffect();
        audioFire.play();

        canfire = true;
          }
	
	
}
