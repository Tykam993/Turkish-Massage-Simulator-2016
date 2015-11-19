using System;
using UnityEngine;


public class InteractiveObject : MonoBehaviour {

    public string toolTip;
    public float size;
    public float vel;
    public float totalPain;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        vel = GetComponent<Rigidbody>().velocity.magnitude;
	}
    public void RemoveMe()
    {
        //gameObject.SetActive(false);
        GameObject.Destroy(gameObject); //hmmm
    }
}
