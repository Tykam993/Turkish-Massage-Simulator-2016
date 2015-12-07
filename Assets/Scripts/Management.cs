using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Management : MonoBehaviour {

    public GameObject client1;
    public GameObject client1Info;
    public GameObject client2;
    public GameObject client2Info;
    public GameObject client3;
    public GameObject client3Info;
    private GameObject currentClient;
    private GameObject selectedClient;
    public GameObject clipboardHome;

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
    void Update() {
        if (currentClient)
        {
            clipboardHome.GetComponent<FlickerFlare>().enabled = false;
            timeRem.text = (clock - Time.time).ToString("F2");
            if (clock < Time.time) {
                timeRem.text = "0:00";
                Win();
            }
        }
        else { 
        clipboardHome.GetComponent<FlickerFlare>().enabled = true;
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
            float startCumf = 100 - currentClient.GetComponent<InteractiveObject>().totalPain + 5;
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
    public void NextC()
    {
        if (!selectedClient)
        {
            float randN = Random.Range(0, 4);
            if (randN <= 1) {
                selectedClient = client1;
            }
            else if (randN >1 && randN <= 2)
            {
                selectedClient = client2;
            }
            else if (randN > 2 && randN <= 3)
            {
                selectedClient = client3;
            }
            else
            {
                NextC();
            }

        }
        else
        {
            if (selectedClient == client1)
            {
                selectedClient = client2;
                client1Info.SetActive(false);
                client2Info.SetActive(true);
                client3Info.SetActive(false);
            }
            else if (selectedClient == client2)
            {
                selectedClient = client3;
                client1Info.SetActive(false);
                client2Info.SetActive(false);
                client3Info.SetActive(true);
            }
            else if (selectedClient == client3)
            {
                selectedClient = client1;
                client1Info.SetActive(true);
                client2Info.SetActive(false);
                client3Info.SetActive(false);
            }



        }

        
    }
    public void SelectClient()
    {
        SpawnClient(selectedClient);
    }
}
