using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationUI : MonoBehaviour
{
   // public GameObject uitext;

    // Start is called before the first frame update
    void Start()
    {
      //  uitext.SetActive(false);
    }
    void OnTriggerEnter(Collider collider)
    {

        if (collider.tag == "Player")
        {
           // uitext.SetActive(true );
           // StartCoroutine("waitforsec");
        }
    }

    IEnumerator waitforsec()
    {
        yield return new WaitForSeconds(1);
      //  uitext.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (0,Time.deltaTime *100,0));
    }
}
