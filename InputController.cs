﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {


    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool Fire1;
    public bool Fire2;
    public bool Reload;
    public bool iswalking;
    public bool issprinting;
    public bool iscrouch;
    public bool MouseWheelUp;
    public bool MouseWheelDown;
    public bool Escape;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input .GetAxisRaw ("Mouse Y") );
        Fire1 = Input.GetButton("Fire1");
        Fire2 = Input.GetButton("Fire2");
        Reload = Input.GetKey(KeyCode.R);
        iswalking = Input.GetKey(KeyCode.Tab);
        issprinting = Input.GetKey(KeyCode.LeftShift);
        iscrouch = Input.GetKey(KeyCode.C);
        MouseWheelUp = Input.GetAxis("Mouse ScrollWheel") > 0;
        MouseWheelDown = Input.GetAxis("Mouse ScrollWheel") < 0 ;

        Escape = Input.GetKey(KeyCode.Escape);

	}
}
