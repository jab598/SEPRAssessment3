using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * 
 * All new code
 * 
 * */

public class ObjectiveIssue : MonoBehaviour {

	/// <summary>
	/// Issue objective on trigger?
	/// </summary>
	public bool issueOnTrigger = true;

	/// <summary>
	/// Name of the mission to issue
	/// </summary>
	public string missionName;

	/// <summary>
	/// Parts of the new mission
	/// </summary>
	public List<string> missionParts = new List<string>();

	//Internal flag
	bool issued = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//On trigger
	void OnTriggerEnter2D(Collider2D c) {
		//If not issued, make a new mission, add the parts, issue it and update the UI.
		if (!issued) {
			Objective newObj = new Objective (missionName);
			foreach (string s in missionParts) {
				newObj.addPart (s);
			}
			ObjectiveHandler.inst.objectives.Add (newObj);
			ObjectiveHandler.inst.UpdateUI ();
			issued = true;
		}
	}
}
