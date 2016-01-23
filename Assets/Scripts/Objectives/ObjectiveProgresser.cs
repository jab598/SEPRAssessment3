using UnityEngine;
using System.Collections;

public class ObjectiveProgresser : MonoBehaviour {

	public bool progressOnCollision = true;
	public bool progressOnTrigger = false;

	public string missionName;

	public bool completeNextPart = true;

	public bool useSideCondition = false;
	public string sideConditionMissionName;
	public bool sideConditionPreviousPart;
	public string sideConditionMissionPart;

	void Start () {

	}

	void OnCollisionEnter2D(Collision2D c) {
		if (progressOnCollision) {
			if (c.transform.tag == "Player") {
				completePart ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (progressOnTrigger) {
			Debug.Log ("Triggered");
			if (c.transform.tag == "Player") {
				Debug.Log ("Player trigger detected");
				completePart ();
			}
		}
	}

	void completePart() {
		if (useSideCondition) {
			if (ObjectiveHandler.instance.checkPart (sideConditionMissionName, sideConditionMissionPart)) {
				ObjectiveHandler.instance.completeNextPart (missionName);
			}
		} else if(!useSideCondition) {
			ObjectiveHandler.instance.completeNextPart (missionName);
		}
		ObjectiveHandler.instance.UpdateUI ();
	}
}
