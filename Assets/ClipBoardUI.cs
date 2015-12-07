using UnityEngine;
using System.Collections;

public class ClipBoardUI : MonoBehaviour {
    public GameObject pencil;
	// Use this for initialization
	void Start () {
        GetComponent<ClipBoardUI>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10))
        {
            if (hit.transform.tag == "ClipBoard")
            {
                Cursor.visible = false;
                pencil.transform.position = hit.point;
            }
            else
            {
                Cursor.visible = true;
            }
        }
    }
    public void Open()
    {

        Cursor.lockState = CursorLockMode.None;//free the cursor
        //Cursor.visible = true;
    }
    public void Close()
    {
        Cursor.lockState = CursorLockMode.Locked; //keep cursor to screen center;
        Cursor.visible = false;

    }
}
