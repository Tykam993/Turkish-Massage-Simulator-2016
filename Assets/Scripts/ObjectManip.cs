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
    private float setDist = 1.0f;
    private bool movingOb;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        setDist = Mathf.Clamp(setDist + (Input.GetAxis("Mouse ScrollWheel")*0.3f), 0.5f, 1.5f);
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
                        carriedOb.GetComponent<InteractiveObject>().SetControllerOb(this.gameObject);

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

            Vector3 holdPos = transform.position + (transform.forward * setDist);

            if (!movingOb)
            {
                carriedOb.transform.position = Vector3.Lerp(carriedOb.transform.position, holdPos, 1);
                carriedOb.transform.rotation = transform.rotation;
            }

            if (Input.GetMouseButton(0))
            {
                movingOb = true;
                carriedOb.GetComponent<InteractiveObject>().PlayMovement();

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                movingOb = false;
                carriedOb.GetComponent<InteractiveObject>().SetControllerOb(null);
                carriedOb.GetComponent<Rigidbody>().isKinematic = false;
                carriedOb = null;
				GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
                setDist = 1.0f;
            }
        }

    }
    public void FinishObjectMove()
    {

        movingOb = false;
    }
}
