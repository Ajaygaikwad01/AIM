using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {
    [SerializeField]
    float minangle;

    [SerializeField]
    float maxangle;

    

    public void SetRotation(float amount)
    {
        float clampangle = GetClampAngle(amount);
        transform.eulerAngles = new Vector3(clampangle, transform.eulerAngles.y, transform.eulerAngles.z);

    }

    private float GetClampAngle(float amount)
    {
        float newangle = checkangle(transform.eulerAngles.x - amount);

        float clampangle = Mathf.Clamp(newangle, minangle, maxangle);
        return clampangle;
    }
    public float GetAngle()
    {
        return checkangle(transform.eulerAngles.x);

    }
    public float  checkangle(float value)
    {

       float angle = value - 180;

       if (angle > 0)
       {
           return angle - 180;
       }
        return angle + 180;

    }

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       // print(GetAngle ());
	}
}
