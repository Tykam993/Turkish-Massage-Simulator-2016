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
        #region no object in hands
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
        #endregion

        #region object in hands
        else
        {
            #region ClipBoard specific
            if (carriedOb.Equals(GameObject.Find("Pseudo_Clip_Board")))
            {
                //find the unit vector/normal vector of the player camera
                GameObject fpsController = GameObject.Find("FPSController");
                float clipFaceMeX = fpsController.transform.rotation.x;
                //find the unit vector/normal vector of the player camera
                float clipFaceMeY = (this.transform.rotation.y + 180) % 360;
                carriedOb.transform.rotation = new Quaternion(clipFaceMeX, clipFaceMeY, 85, 0);
                carriedOb.transform.position = new Vector3(this.transform.position.x,
                    this.transform.position.y / 20 * 19,
                    this.transform.position.z);
            }
            #endregion
            #region Anything that isn't a ClipBoard
            else
            {
                Vector3 holdPos = transform.position + transform.forward;
                //Vector3 holdPos = transform.position;
                // holdPos.z = holdPos.z + carriedOb.GetComponent<InteractiveObject>().size;
                
                carriedOb.transform.position = Vector3.Lerp(carriedOb.transform.position, holdPos, 1);
            }
            #endregion
            #region All objects
            if (Input.GetKeyDown(KeyCode.E))
            {
                carriedOb.GetComponent<Rigidbody>().isKinematic = false;
                carriedOb = null;
				GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
                
            }
            #endregion
        }
        #endregion

    }
}
