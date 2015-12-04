using UnityEngine;
using System.Collections;

public class ClientSelect : MonoBehaviour {
	
	public GameObject client1;
	public GameObject client2;
	public GameObject client3;
	public GameObject client4;
	public GameObject client5;
	public GameObject client6;
	public GameObject client7;
	public GameObject client8;
	public GameObject client9;
	public GameObject client10;

	public Camera gameCam;
	public Camera clipCam;

	GameObject[] clients = new GameObject[10];
	int HEIGHT, WIDTH;

	// Use this for initialization
	void Start () {
		clients[0] = client1;
		clients[1] = client2;
		clients[2] = client3;
		clients[3] = client4;
		clients[4] = client5;
		clients[5] = client6;
		clients[6] = client7;
		clients[7] = client8;
		clients[8] = client9;
		clients[9] = client10;

		gameCam.enabled = true;
		clipCam.enabled = false;

		HEIGHT = (int) gameObject.transform.lossyScale.x;
		WIDTH  = (int) gameObject.transform.lossyScale.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.C)) {
			gameCam.enabled = !gameCam.enabled;
			clipCam.enabled = !clipCam.enabled;
		}
	}
}
