using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    public float fadeRate;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().color = Color.Lerp(GetComponent<Text>().color, Color.clear, fadeRate);
	}
}
