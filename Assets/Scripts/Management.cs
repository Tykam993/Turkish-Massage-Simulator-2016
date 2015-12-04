﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Management : MonoBehaviour {

    public GameObject client1;
    public GameObject client2;
    public GameObject client3;
    private GameObject currentClient;
    


    private float cTime = 20; // the amount of time to massage the current client
    private float clock;

    public Text stamVal;
    public Text cumfVal;
    public Text clientName;
    public Text timeRem;
    public float curCliVal;
    public AudioClip success;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (currentClient)
        {
            timeRem.text = (clock - Time.time).ToString("F2");
            if (clock < Time.time) {
                timeRem.text = "0:00";
                Win();
            }
        }

	if (curCliVal >= 100)
        {
            Win();
        }
	}
    public void SpawnClient(GameObject client)
    {

        if (client)
        {
            if (currentClient)
            {
                currentClient.GetComponent<InteractiveObject>().RemoveMe();
            }
            GameObject newClient = (GameObject)Instantiate(client, transform.position, transform.rotation);

            currentClient = newClient;
            cTime = currentClient.GetComponent<ClientBehavior>().timeWithClient;
            clientName.text = currentClient.GetComponent<ClientBehavior>().clientName;
            float startCumf = 100 - currentClient.GetComponent<InteractiveObject>().totalPain;
            cumfVal.text = startCumf.ToString();
            curCliVal = startCumf;
        }
       


        clock = Time.time + cTime;
    }
    public void SpawnClientRand()
    {

            float rNum = Random.Range(1, 4);
            if (rNum <= 1)
            {
                if (currentClient)
                {
                    currentClient.GetComponent<InteractiveObject>().RemoveMe();
                }
                GameObject newClient = (GameObject)Instantiate(client1, transform.position, transform.rotation);

                currentClient = newClient;
            
            float startCumf = 100 - currentClient.GetComponent<InteractiveObject>().totalPain;
                cumfVal.text = startCumf.ToString();
                curCliVal = startCumf;

            }
            else if (rNum > 1 && rNum <= 2)
            {
                if (currentClient)
                {
                    currentClient.GetComponent<InteractiveObject>().RemoveMe();
                }
                GameObject newClient = (GameObject)Instantiate(client2, transform.position, transform.rotation);


                currentClient = newClient;

            float startCumf = 100 - currentClient.GetComponent<InteractiveObject>().totalPain;
                cumfVal.text = startCumf.ToString();

            }
            else if (rNum > 2 && rNum <= 3)
            {
                if (currentClient)
                {
                    currentClient.GetComponent<InteractiveObject>().RemoveMe();
                }
                GameObject newClient = (GameObject)Instantiate(client3, transform.position, transform.rotation);


                currentClient = newClient;

            float startCumf = 100 - currentClient.GetComponent<InteractiveObject>().totalPain;
                cumfVal.text = startCumf.ToString();

            }
        cTime = currentClient.GetComponent<ClientBehavior>().timeWithClient;
        clientName.text = currentClient.GetComponent<ClientBehavior>().clientName;

        clock = Time.time + cTime;


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