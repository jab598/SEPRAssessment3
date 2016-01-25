using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveIssue : MonoBehaviour {

	public bool issueOnTrigger = true;
	public bool issueOnCollision = false;

	public string missionName;
	public List<string> missionParts = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (issueOnTrigger) {
			Objective newObj = new Objective (missionName);
			foreach(string s in missionParts) {
				newObj.addPart(s);
			}
			ObjectiveHandler.instance.objectives.Add (newObj);
			ObjectiveHandler.instance.UpdateUI();
		}
	}
}
