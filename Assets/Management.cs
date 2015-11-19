using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Management : MonoBehaviour {

    public GameObject client1;
    public GameObject client2;
    private GameObject currentClient;
    
    private bool skel = false;

    public Text stamVal;
    public Text cumfVal;
    public float curCliVal;
    public AudioClip success;
    // Use this for initialization
    void Start () {
        skel = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (curCliVal >= 100)
        {

            Win();
        }
	}
    public void SpawnClient()
    {

        if (skel == false)
        {
            if (currentClient)
            {
                currentClient.GetComponent<InteractiveObject>().RemoveMe();
            }
            GameObject newClient = (GameObject)Instantiate(client2, transform.position, transform.rotation);

            currentClient = newClient;
            float startCumf = 100 - currentClient.GetComponent<InteractiveObject>().totalPain;
            cumfVal.text = startCumf.ToString();
            curCliVal = startCumf;
            skel = true;
        }
        else if (skel == true)
        {
            if (currentClient)
            {
                currentClient.GetComponent<InteractiveObject>().RemoveMe();
            }
            GameObject newClient = (GameObject)Instantiate(client1, transform.position, transform.rotation);

            
            currentClient = newClient;
            float startCumf = 100 - currentClient.GetComponent<InteractiveObject>().totalPain;
            cumfVal.text = startCumf.ToString();
            skel = false;
        }



    }
    public void Win(){

        if (currentClient)
        {
            currentClient.GetComponent<InteractiveObject>().RemoveMe();

        }
        curCliVal = 0;
        cumfVal.text = "0";
        GetComponent<AudioSource>().PlayOneShot(success);
    }
}
