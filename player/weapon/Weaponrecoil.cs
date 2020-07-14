using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Shooter ))]
public class Weaponrecoil : MonoBehaviour {


    [System.Serializable]
    public struct Layer
    {
        public AnimationCurve curve;
        public Vector3 direction;


    }

    [SerializeField]
    Layer[] layers;

    [SerializeField]
    float recoilspeed;

    [SerializeField]
    float recoilcooldown;

    [SerializeField]
    float strangth;

    float nextrecoilcooldown;
    float recoilactivetime;

    Shooter m_shooter;
    Shooter shooter
    {
        get
        {
            if(m_shooter ==null )
            m_shooter = GetComponent<Shooter>();
          
            return m_shooter;

        }

    }


    Crosshair m_Crosshair;
    Crosshair Crosshair
    {
        get
        {
            if (m_Crosshair == null)
                m_Crosshair = GameManager.Instance.localplayer.playerraim.GetComponentInChildren<Crosshair>();

            return m_Crosshair;

        }

    }
    public void Activate()
    {
        nextrecoilcooldown = Time.time + recoilcooldown;

    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (nextrecoilcooldown > Time.time)
        {
            recoilactivetime += Time.deltaTime;
            float percentage = getpercentage();

            Vector3 recoilammount = Vector3.zero ;
           
            for (int i = 0; i < layers.Length; i++ )
                recoilammount += layers[i].direction * layers[i].curve.Evaluate(percentage );


            this.shooter.AimTargetOffSet = Vector3.Lerp(shooter .AimTargetOffSet ,shooter.AimTargetOffSet +recoilammount ,strangth * Time .deltaTime );
            this.Crosshair.ApplyScale(percentage *  Random .Range(strangth * 2,strangth * 3));
        }

        else
        {
            recoilactivetime -= Time.deltaTime;

            if (recoilactivetime < 0)
                recoilactivetime = 0;

            this.Crosshair.ApplyScale(getpercentage ());

            if (recoilactivetime == 0)
            {
                this.shooter.AimTargetOffSet = Vector3.zero;
                this.Crosshair.ApplyScale(0);
            }
        }

	}

    float getpercentage()
    {
        float percentage = recoilactivetime / recoilspeed;
       return Mathf.Clamp01(percentage);

    }
}
