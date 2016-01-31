using UnityEngine;
using System.Collections;

/*
 * 
 * All new code
 * Used exclusively in the computer science scene to turn the lights back on.
 * 
 * */

public class CSLightsOn : MonoBehaviour {

	public Light directLight;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Player") {
			directLight.intensity = 0.8f;
		}
	}
}
