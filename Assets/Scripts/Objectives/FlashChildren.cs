using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 
 * All new code
 * 
 * */

/// <summary>
/// Activates one child object at a time, giving a flashing line effect.
/// </summary>
public class FlashChildren : MonoBehaviour {

	/// <summary>
	/// Time taken between flashes in seconds
	/// </summary>
	public float flashSpeed = 1;

	//the time that the next flash will occur
	float nextFlashTime;

	//current child to disable
	int currentChildIndex = 0;

	public List<GameObject> children = new List<GameObject>();

	// Use this for initialization
	void Start () {
		//initialise the variables; 
		nextFlashTime = Time.time + flashSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (children.Count == 1) {
			return;
		} else {
			//if the time is past when we should have flashed
			if (Time.time > nextFlashTime) {
				//iterate through childre, set one active, and the rest inactive
				for (int i = 0; i < children.Count; i++) {
					if (i == currentChildIndex) {
						children [i].SetActive (true);
					} else {
						children [i].SetActive (false);
					}
				}
				//set the next flash time and the new child index
				nextFlashTime = Time.time + flashSpeed;
				currentChildIndex++;
				if(currentChildIndex > children.Count){
					currentChildIndex = 0;
				}
			}
		}
	}
}
