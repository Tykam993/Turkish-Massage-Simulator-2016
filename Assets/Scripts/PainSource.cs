using UnityEngine;
using System.Collections;

public class PainSource : MonoBehaviour {
    public float deepPainLvl;
    public float surfPainLvl;
    public float painAmt;
    public AudioClip great, good, ok, meh, erm, ow;
    public Color painLevels;
    public bool ready = false;
    public  GameObject manager;

	// Use this for initialization
	void Start () {
        ClearPain();
        painLevels = new Color(surfPainLvl, 0, deepPainLvl);
        manager = GameObject.FindGameObjectWithTag ( "Manage" );
    }
	
	// Update is called once per frame
	void Update () {
        manager = GameObject.FindGameObjectWithTag("Manage");
        if (surfPainLvl <= 0)
        {

            Removepain();
        }
    }
    void ClearPain()
    {
        if (ok && ready)
        {
            GetComponent<AudioSource>().PlayOneShot(ok);
            ready = true;
        }
        painLevels = new Color(surfPainLvl, 1 - (surfPainLvl+ deepPainLvl), deepPainLvl);
        GetComponent<ParticleSystem>().startColor = painLevels;
        if (manager && surfPainLvl > 0)
        {
            Management mm = manager.GetComponent<Management>();
            mm.curCliVal = mm.curCliVal + 1.0f;
            mm.cumfVal.text = mm.curCliVal.ToString();
        }
        

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<InteractiveObject>() && other != transform.parent.gameObject)
        {
            GetComponent<ParticleSystem>().startSize = 0.15f;
            GetComponent<ParticleSystem>().startColor = Color.white;
            deepPainLvl = Mathf.Clamp(deepPainLvl - 0.1f, 0, 1);
            surfPainLvl = Mathf.Clamp(surfPainLvl - 0.1f, 0, 1);
            ClearPain();

        }

    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<InteractiveObject>() && other != transform.parent.gameObject)
        {
            GetComponent<ParticleSystem>().startSize = 0.06f;


        }

    }
    void Removepain()
    {

        Destroy(gameObject);
    }
}
