using UnityEngine;
using System.Collections;

public class PainSource : MonoBehaviour {
    public float deepPainLvl;
    public float surfPainLvl;
    public float painAmt;
    public AudioClip great, good, ok, meh, erm, ow;
    public Color painLevels;
	// Use this for initialization
	void Start () {
        ClearPain();
        painLevels = new Color(surfPainLvl, 0, deepPainLvl);
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    void ClearPain()
    {
        if (ok)
        {
            GetComponent<AudioSource>().PlayOneShot(ok);
        }
        painLevels = new Color(surfPainLvl, 1 - (surfPainLvl+ deepPainLvl), deepPainLvl);
        GetComponent<ParticleSystem>().startColor = painLevels;


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractiveObject>())
        {
            deepPainLvl = Mathf.Clamp(deepPainLvl - 0.1f, 0, 1);
            surfPainLvl = Mathf.Clamp(surfPainLvl - 0.1f, 0, 1);
            ClearPain();

        }
    }
}
