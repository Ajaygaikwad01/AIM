using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeTaget : Destructable {

    [SerializeField]
    float RotatinSpeed;
    [SerializeField]
    float repairtime;

    Quaternion InitialRotation;
    Quaternion targetRotation;
    bool requiredrotation;
    
    // Use this for initialization
	void Awake() {
        InitialRotation = transform.rotation;

	}

    public override void Die()
    {
        base.Die();
        targetRotation = Quaternion.Euler(transform .right * 90);
        requiredrotation = true;
        GameManager.Instance.Timer.Add(() =>
            {
                targetRotation = InitialRotation;
                requiredrotation = true;


            }, repairtime);
    }

	// Update is called once per frame
	void Update () {
        if (!requiredrotation)
            return;

        transform.rotation = Quaternion.Lerp(transform .rotation , targetRotation , RotatinSpeed * Time .deltaTime );

        if (transform.rotation == targetRotation)
            requiredrotation = false;
	}
}
