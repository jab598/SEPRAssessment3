using UnityEngine;
using System.Collections;

/*
 * 
 * All new, an attempt to increase performance of the game once loaded
 * 
 * */

public class LoadAllResources : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Resources.LoadAll ("/resources");
	}

}
