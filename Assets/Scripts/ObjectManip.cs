using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ObjectManip : MonoBehaviour {


    public GameObject carriedOb;
    public GameObject tTipText;

	private Vector3 clipBoardPos = new Vector3(0.734f, 0.31f, -9.412f);
	private Vector3 clipBoardRot = new Vector3(0, 218.3478f, 0);

	public GameObject clipboard;
    public float pickupDist;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!carriedOb)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDist))
            {

                if (hit.transform.gameObject.GetComponent<InteractiveObject>())
                    {
                    tTipText.GetComponent<Text>().text = hit.transform.gameObject.GetComponent<InteractiveObject>().toolTip;
                    tTipText.GetComponent<Text>().color = Color.white;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        carriedOb = hit.transform.gameObject;
                        carriedOb.GetComponent<Rigidbody>().isKinematic = true;
                    }
                }

				if (hit.transform.gameObject.tag == "Interface") { //hit.transform.gameObject.GetComponent<InteractiveObject>() && hit.transform.gameObject.tag == "Interface") {
					tTipText.GetComponent<Text>().text = hit.transform.gameObject.GetComponent<InteractiveObject>().toolTip;
					tTipText.GetComponent<Text>().color = Color.white;


					if (Input.GetKeyDown(KeyCode.E)) {

						GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
						Vector3 holdPos = transform.position + transform.forward;

						//Instantiate(clipboard, transform.position + transform.forward*1, transform.rotation);
					}

				}
               
            }

        }


        else
        {

            Vector3 holdPos = transform.position + transform.forward;
            //Vector3 holdPos = transform.position;
            // holdPos.z = holdPos.z + carriedOb.GetComponent<InteractiveObject>().size;

            carriedOb.transform.position = Vector3.Lerp(carriedOb.transform.position, holdPos, 1);
            if (Input.GetKeyDown(KeyCode.E))
            {
                carriedOb.GetComponent<Rigidbody>().isKinematic = false;
                carriedOb = null;
				GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
                
            }
        }

    }
}
