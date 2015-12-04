using UnityEngine;
using System.Collections;

public class ClientBehavior : MonoBehaviour {

    public int painAmt;
    public string clientName;
    public GameObject painInd;
    private int painCount = 0;
    public float timeWithClient; // The amount of time of the appointment in seconds.
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	    if (painCount <= painAmt)
        {

            CastPain();
        }


	}
    void CastPain ()
    {
        

        float randX = Random.Range(-0.5f, 0.5f);
        float randZ = Random.Range(-0.5f, 1f);
        RaycastHit hit;

        Vector3 castFrom = transform.position;
        castFrom.y = castFrom.y + 2;
        castFrom.x = castFrom.x + randX;
        castFrom.z = castFrom.z + randZ;
        if (Physics.Raycast(castFrom, transform.forward, out hit, 10.0f))
        {
            if (hit.transform.tag == "Client")
            {
                GameObject newPain = (GameObject)Instantiate(painInd, hit.point, transform.rotation);
                newPain.transform.parent = hit.transform;
                painCount = painCount + 1;
            }
        }

    }
}
