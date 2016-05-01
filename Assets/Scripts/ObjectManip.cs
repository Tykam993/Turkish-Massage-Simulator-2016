using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ObjectManip : MonoBehaviour
{
    public Transform handLeft;
    public Transform handRight;

    public GameObject carriedOb;
    public GameObject tTipText;

    private Vector3 clipBoardPos = new Vector3(0.734f, 0.31f, -9.412f);
    private Vector3 clipBoardRot = new Vector3(0, 218.3478f, 0);
    
    public GameObject clipboard;
    public GameObject clipboardHome;
    public float pickupDist;
    private float setDist = 1.0f;
    private bool movingOb;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        setDist = Mathf.Clamp(setDist + (Input.GetAxis("Mouse ScrollWheel") * 0.3f), 0.5f, 1.5f);
        if (!carriedOb)
        {
            if (Input.GetMouseButton(0))
            {
                handLeft.GetComponent<Rigidbody>().isKinematic = true;
                handRight.GetComponent<Rigidbody>().isKinematic = true;
                RaycastHit hitHands;
                if (Physics.Raycast(transform.position, transform.forward, out hitHands, 0.9f))
                {
                    handLeft.position = Vector3.Lerp(handLeft.position, transform.position + (transform.forward * hitHands.distance) + transform.right * -0.12f, Time.deltaTime * 1.5f);
                    handRight.position = Vector3.Lerp(handRight.position, transform.position + (transform.forward * hitHands.distance) + transform.right * 0.12f, Time.deltaTime * 1.5f);
                }
                else
                {
                    handLeft.position = Vector3.Lerp(handLeft.position, transform.position + (transform.forward * 0.7f) + transform.right * -0.12f, Time.deltaTime * 1.5f);
                    handRight.position = Vector3.Lerp(handRight.position, transform.position + (transform.forward * 0.7f) + transform.right * 0.12f, Time.deltaTime * 1.5f);
                }

            }
            else
            {
                handLeft.GetComponent<Rigidbody>().isKinematic = false;
                handRight.GetComponent<Rigidbody>().isKinematic = false;
            }


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
                if (hit.transform.tag == "Door")
                {
                    tTipText.GetComponent<Text>().text = "Push E to Exit";
                    tTipText.GetComponent<Text>().color = Color.white;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        Application.LoadLevel("Main_Menu");
                    }


                }

                if (hit.transform.gameObject == clipboard.gameObject)
                {
                    tTipText.GetComponent<Text>().text = "Hit E to select clients";
                    tTipText.GetComponent<Text>().color = Color.black;


                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        carriedOb = clipboard.gameObject;
                        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = false;
                        clipboard.GetComponent<ClipBoardUI>().enabled = true;
                        clipboard.GetComponent<ClipBoardUI>().Open();
                        setDist = 0.45f;
                        Vector3 holdPos = transform.position + (transform.forward* setDist);

                        clipboard.transform.position = holdPos;
                        clipboard.transform.rotation = transform.rotation;
                    }

                }

            }

        }


        else
        {
            if (carriedOb.gameObject != clipboard.gameObject)
            {
                Vector3 holdPos = transform.position + (transform.forward * setDist);

                if (!movingOb)
                {
                    carriedOb.transform.position = Vector3.Lerp(carriedOb.transform.position, holdPos, 1);
                    carriedOb.transform.rotation = transform.rotation * carriedOb.GetComponent<InteractiveObject>().offsetRot;
                }

                if (Input.GetMouseButton(0))
                {
                    movingOb = true;
                    carriedOb.GetComponent<InteractiveObject>().PlayMovement();

                }
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (carriedOb.GetComponent<InteractiveObject>())
                {
                    movingOb = false;
                    carriedOb.GetComponent<InteractiveObject>().SetControllerOb(null);
                    carriedOb.GetComponent<Rigidbody>().isKinematic = false;
                    carriedOb = null;
                    GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
                    setDist = 1.0f;
                }
                else if (carriedOb.gameObject == clipboard.gameObject)
                {

                    EndClipBoard();
                    
                }
            }
        }

    }
    public void FinishObjectMove()
    {

        movingOb = false;
    }
    public void EndClipBoard()
    {
        carriedOb = null;
        GameObject.Find("FPSController").GetComponent<FirstPersonController>().enabled = true;
        clipboard.GetComponent<ClipBoardUI>().Close();
        clipboard.GetComponent<ClipBoardUI>().enabled = false;
        clipboard.transform.position = clipboardHome.transform.position;
        clipboard.transform.rotation = clipboardHome.transform.rotation;

    }
}
