using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;
using System.Collections;

public class InteractiveObject : MonoBehaviour {

    public string toolTip;
    public float size;
    public float vel;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        vel = GetComponent<Rigidbody>().velocity.magnitude;
	}
}
