using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth2 : Destructable {

    // DEATHMENU dethmenu;


    public GameObject deathMenuPref;

    [SerializeField]
    Slider slider;

    [SerializeField]
    Text text;

    public float flashSpeed = 5f;
   
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
   
    public Image damageImage;

   //  damageImage.color = flashColour;
    
       // damageImage.color = Color.clear;
    private GameMaster gm;
    [SerializeField]
    RegDoll radoll;

  
    void Start()
    {
        
       gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
       

    }


  public  void spwanatnewspwanpoint()
    {
     
        transform.position = gm.lastcheckpointpos;

        deathMenuPref.SetActive(false);

    }
    public override void Die()
    {
        base.Die();
        //radoll.EnableRagdoll(true);
       // Destroy(gameObject, 3f);

       // dethmenu.ToggleEndMenu();
        deathMenuPref.SetActive(true);
        GameManager.Instance.playerIsPaused = true;

      //  spwanatnewspwanpoint();
        Reset();
    }
    public override void Takedamage(float amount)
    {
        print("remaining:" + Hitpointremaining);
        base.Takedamage(amount);
        text.text = string.Format("{0}", Hitpointremaining);
        slider.value = Hitpointremaining;

         damageImage.color = flashColour;
       //damageImage = true;
        // damageImage.color = Color.clear;

    }

    void Update()
    {
        damageImage.color = Color.clear; 
    }
}
