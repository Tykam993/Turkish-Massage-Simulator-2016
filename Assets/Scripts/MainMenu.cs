using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public bool isStart;
    public bool isSettings;
    public bool isQuit;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    #region clicking things
    void OnMouseUp()
    {
        if (isStart)
        {
            //Application.LoadLevel(1);
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        if( isSettings)
        {
            //Application.LoadLevel(2);
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (isQuit)
        {
            Application.Quit();
        }
    }
    #endregion
}
