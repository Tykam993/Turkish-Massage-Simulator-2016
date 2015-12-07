using UnityEngine;
using System.Collections;

public class FlickerFlare : MonoBehaviour {
    private LensFlare myFlare;
    public float baseBrightness = 1;
    public float flickerAmt;
	// Use this for initialization
	void Start () {
       myFlare =  GetComponent<LensFlare>();
	}
	
	// Update is called once per frame
	void Update () {
	 if (!myFlare)
        {
            myFlare = GetComponent<LensFlare>();
        }
        float flicker = Random.Range(-flickerAmt, flickerAmt);
        myFlare.brightness = Mathf.Clamp(baseBrightness + flicker, 0, baseBrightness + flickerAmt);
	}
}
