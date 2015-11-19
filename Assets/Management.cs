using UnityEngine;
using System.Collections;



public class Management : MonoBehaviour {

    public GameObject client1;
    public GameObject client2;
    private GameObject currentClient;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SpawnClient()
    {

        if (currentClient == client1)
        {
           GameObject newClient = (GameObject)Instantiate(client2, transform.position, transform.rotation);
            currentClient = client2;
        }
        else if (currentClient == client2)
        {
            GameObject newClient = (GameObject)Instantiate(client1, transform.position, transform.rotation);
            currentClient = client1;
        }
        else
        {
            GameObject newClient = (GameObject)Instantiate(client1, transform.position, transform.rotation);
            currentClient = client1;
        }

    }
}
