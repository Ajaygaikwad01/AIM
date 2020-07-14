using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIshow : MonoBehaviour
{
   private AudioSource pickupitemSound;
   // [SerializeField]
    //AudioController pickupitemSound;

    public GameObject uiHealthText;

    public GameObject M4AmmoText;
    public GameObject AkAmmoText;
    public GameObject MachineAmmoText;
    public GameObject SMGAmmoText;
    public GameObject ShotgunAmmoText;

    // Start is called before the first frame update
    void Start()
    {
        uiHealthText.SetActive(false);

        M4AmmoText.SetActive(false);
        AkAmmoText.SetActive(false);
        MachineAmmoText.SetActive(false);
        SMGAmmoText.SetActive(false);
        ShotgunAmmoText.SetActive(false);

        pickupitemSound = GetComponent<AudioSource>();

    }

    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "m4ammo")
        {
            M4AmmoText.SetActive(true);
            StartCoroutine("waitforsec");

           pickupitemSound.Play();
        }

        if (collider.tag == "akammo")
        {
            AkAmmoText.SetActive(true);
            StartCoroutine("waitforsec");

           pickupitemSound.Play();
        }

        if (collider.tag == "machineammo")
        {
            MachineAmmoText.SetActive(true);
            StartCoroutine("waitforsec");
            
            pickupitemSound.Play();
        }

        if (collider.tag == "smgammo")
        {
            SMGAmmoText.SetActive(true);
            StartCoroutine("waitforsec");

            pickupitemSound.Play();
        }

        if (collider.tag == "shotammo")
        {
            ShotgunAmmoText.SetActive(true);
            StartCoroutine("waitforsec");

            pickupitemSound.Play();
        }

        if (collider.tag == "healthkit")
        {
            uiHealthText.SetActive(true);
             StartCoroutine("waitforsec");

             pickupitemSound.Play();
        }
    }

    IEnumerator waitforsec()
    {
        yield return new WaitForSeconds(2);
        uiHealthText.SetActive(false);

        M4AmmoText.SetActive(false);
        AkAmmoText.SetActive(false);
        MachineAmmoText.SetActive(false);
        SMGAmmoText.SetActive(false);
        ShotgunAmmoText.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
