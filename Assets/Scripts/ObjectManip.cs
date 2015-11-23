using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ObjectManip : MonoBehaviour {


    public GameObject carriedOb;
    public GameObject tTipText;


    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (!carriedOb)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
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
