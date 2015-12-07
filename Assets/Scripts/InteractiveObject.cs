using System;
using UnityEngine;


public class InteractiveObject : MonoBehaviour
{

    public string toolTip;
    public float size;

    public float totalPain;
    public Vector3 hardWetTemp; // stored as vector3 can be negative or positive, if 0 than neutral.
    private int moving;
    private Vector3 startPos;
    public Vector3 movePos1, movePos2, movePos3, movePos4; // where the object is moved to.
    public float moveSpeed = 1;
    private GameObject controllerOb;

    // Use this for initialization
    void Start()
    {
        if (moveSpeed == 0)
        {
            moveSpeed = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (controllerOb)
        {
            float dist = Vector3.Distance(transform.position, controllerOb.transform.position);
            if (moving == 1)
            {
                Vector3 newPos = controllerOb.transform.position + controllerOb.transform.forward * movePos1.z;
                newPos = newPos + controllerOb.transform.right * movePos1.x;
                newPos = newPos + controllerOb.transform.up * movePos1.y;
                transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * dist * dist * Time.deltaTime);
                if (transform.position == newPos)
                {
                    moving = 2;
                }
            }
            else if (moving == 2)
            {
                Vector3 newPos = controllerOb.transform.position + controllerOb.transform.forward * movePos2.z;
                newPos = newPos + controllerOb.transform.right * movePos2.x;
                newPos = newPos + controllerOb.transform.up * movePos2.y;
                transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * dist * dist * Time.deltaTime);
                if (transform.position == newPos)
                {
                    moving = 3;
                }
            }
            else if (moving == 3)
            {
                Vector3 newPos = controllerOb.transform.position + controllerOb.transform.forward * movePos3.z;
                newPos = newPos + controllerOb.transform.right * movePos3.x;
                newPos = newPos + controllerOb.transform.up * movePos3.y;
                transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * dist * dist * Time.deltaTime);
                if (transform.position == newPos)
                {
                    moving = 4;
                }
            }
            else if (moving == 4)
            {
                Vector3 newPos = controllerOb.transform.position + controllerOb.transform.forward * movePos4.z;
                newPos = newPos + controllerOb.transform.right * movePos4.x;
                newPos = newPos + controllerOb.transform.up * movePos4.y;
                transform.position = Vector3.MoveTowards(transform.position, newPos, moveSpeed * dist * dist * Time.deltaTime);
                if (transform.position == newPos)
                {
                    moving = 5;
                }
            }
            else if (moving == 5)
            {
                moving = 0;
                controllerOb.GetComponent<ObjectManip>().FinishObjectMove();


            }
        }
        else
        {
            moving = 0;
        }




    }
    public void RemoveMe()
    {
        //gameObject.SetActive(false);
        GameObject.Destroy(gameObject); //hmmm
    }
    public void PlayMovement()
    {
        if (moving == 0)
        {
            startPos = transform.position;
            moving = 1;
        }

    }
    public void SetControllerOb(GameObject newControl)
    {

        controllerOb = newControl;
    }
}
