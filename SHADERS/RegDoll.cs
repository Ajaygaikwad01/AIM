using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegDoll : MonoBehaviour {

    public Animator animator;
    private Rigidbody[] bodyparts;

	// Use this for initialization
	void Start () {
		bodyparts =transform .GetComponentsInChildren <Rigidbody>();
        EnableRagdoll(false );
	}


    public void EnableRagdoll(bool value)
    {
        animator.enabled = !value;
        for (int i = 0; i < bodyparts.Length; i++)
        {
            bodyparts[i].isKinematic = !value;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
