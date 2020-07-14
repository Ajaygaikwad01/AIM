using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelth : Destructable
{
    public GameObject flotingtext;

    public GameObject scanner;

    [SerializeField]
    AudioController dieaudio;

   // private GameMaster gm;

  //  public GameObject[] ItemDeadState = null;

    public GameObject item;

    [SerializeField]
    RegDoll regdoll;



    void Start()
    {

    //    gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        Reset();
    }

    void spwanatnewspwanpoint()
    {

       // transform.position = gm.lastcheckpointpos;

    }

    public override void Die()
    {
       base.Die();
        regdoll.EnableRagdoll(true);

        Instantiate(item, transform.position, transform.rotation);

        ///scanner.SetActive(false);


        Destroy(GetComponent <CapsuleCollider >());
       

      ///Destroy(gameObject,11f);

     
        dieaudio.play();
    }
      

    void showflotintext()
    {
        var go = Instantiate(flotingtext, transform.position,Quaternion.identity, transform);
       go.GetComponent<TextMesh>().text = Hitpointremaining.ToString();
      
    }

    public override void Takedamage(float amount)
    {
        print("remaining:" + Hitpointremaining);
       base.Takedamage(amount);

      

       if (Hitpointremaining == 0)
       {
           UiShow2.killvalue += 1;
       }

       if (flotingtext != null && Hitpointremaining > 0)

        {
            showflotintext();
           UiShow2.scorevalue += 10;
                     
        }
    }
  
}