using UnityEngine;
using System.Collections;

public class PainSource : MonoBehaviour {

    public float surfPainLvl;

    public AudioClip great, good, ok, meh, erm, ow;
    public Color painLevels;
    public bool ready = false;
    public  GameObject manager;
    private bool discovered;

	// Use this for initialization
	void Start () {
        ClearPain();
        painLevels = new Color(surfPainLvl, 0, 0);
        manager = GameObject.FindGameObjectWithTag ( "Manage" );
    }
	
	// Update is called once per frame
	void Update () {
        manager = GameObject.FindGameObjectWithTag("Manage");
        if (surfPainLvl <= 0)
        {

            Removepain();
        }
        if (surfPainLvl <1 && !discovered)
        {
            transform.root.gameObject.GetComponent<ClientBehavior>().PainFound();
            discovered = true;
        }
    }
    void ClearPain()
    {
        if (ok && ready)
        {
            GetComponent<AudioSource>().PlayOneShot(ok);
            ready = true;
        }
        painLevels = new Color(surfPainLvl, 1 - surfPainLvl, 0);
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
        transform.root.gameObject.GetComponent<ClientBehavior>().PainRemoved();
        Destroy(gameObject);
    }
}
