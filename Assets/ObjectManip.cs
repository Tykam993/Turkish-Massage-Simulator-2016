using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2.5f))
            {
                Debug.DrawRay(transform.position, transform.forward, Color.green, 2.5f);
                if (hit.transform.gameObject.GetComponent<InteractiveObject>())
                    {
                    tTipText.GetComponent<Text>().text = hit.transform.gameObject.GetComponent<InteractiveObject>().toolTip;
                    tTipText.GetComponent<Text>().color = Color.white;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        carriedOb = hit.transform.gameObject;
                    }
                }
               
            }
        }
        else
        {

            Vector3 holdPos = transform.TransformPoint(transform.position);
            //Vector3 holdPos = transform.position;
            holdPos.z = holdPos.z + carriedOb.GetComponent<InteractiveObject>().size;
            carriedOb.transform.position = Vector3.Lerp(carriedOb.transform.position, holdPos, 1);
        }
    }
}
