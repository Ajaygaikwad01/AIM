using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoswitch : MonoBehaviour
{
    
    public int selectedlogo=0;
    // Start is called before the first frame update
    void Start()
    {
        selectlogo(); 
    }
    void selectlogo()
    {
        int i=0;
        foreach (Transform weaponlogo in transform)
        {
            if (i == selectedlogo)
                weaponlogo.gameObject.SetActive(true);
            else
                weaponlogo.gameObject.SetActive(false);

            i++;
        }

    }
    // Update is called once per frame
    void Update()
    {
        int priviousselectlogo = selectedlogo;

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (selectedlogo >= transform.childCount - 1)
                selectedlogo = 0;
            else
            selectedlogo++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (selectedlogo <= 0)
                selectedlogo = transform.childCount - 1;
            else
                selectedlogo--;
        }

        if (priviousselectlogo != selectedlogo)
        {
            selectlogo();
        }
    }
}
