using UnityEngine;
using System.Collections;

/*
 * 
 * All new code
 * 
 * */

public class ObjectiveProgresser : MonoBehaviour {

	/// <summary>
	/// Progress mission on collision?
	/// </summary>
	public bool progressOnCollision = true;

	/// <summary>
	/// PRogress mission on trigger?
	/// </summary>
	public bool progressOnTrigger = false;

	/// <summary>
	/// Destroy the object when player hits it?
	/// </summary>
	public bool destroyOnHit;

	/// <summary>
	/// Update the players state?
	/// </summary>
	public bool updatePlayerState = false;

	/// <summary>
	/// Update the players state to:
	/// </summary>
	public string updatedState;

	/// <summary>
	/// The name of the mission to progress.
	/// </summary>
	public string missionName;

	/// <summary>
	/// Complete the next part of the mission?
	/// </summary>
	public bool completeNextPart = true;

	/// <summary>
	/// Use a side condition?
	/// </summary>
	public bool useSideCondition = false;

	/// <summary>
	/// The name of the side condition mission.
	/// </summary>
	public string sideConditionMissionName;

	/// <summary>
	/// Use the previous part of this mission as the side condition?
	/// </summary>
	public bool sideConditionPreviousPart;

	/// <summary>
	/// The side condition mission part.
	/// </summary>
	public string sideConditionMissionPart;

	void Start () {

	}

	void OnCollisionEnter2D(Collision2D c) {
		//make check and complete part
		if (progressOnCollision) {
			if (c.transform.tag == "Player") {
				CompletePart ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D c) {
		///Make check and complete part
		if (progressOnTrigger) {
			if (c.transform.tag == "Player") {
				CompletePart ();
			}
		}
	}

	/// <summary>
	/// Completes the specified part of the mission
	/// </summary>
	void CompletePart() {
		//If we use a side condition, check the side condition and complete the mission
		if (useSideCondition) {
			if (ObjectiveHandler.inst.checkPart (sideConditionMissionName, sideConditionMissionPart)) {
				ObjectiveHandler.inst.completeNextPart (missionName);
			}
			//Else, we arent using a side condition, so just complete the next part
		} else if(!useSideCondition) {
			ObjectiveHandler.inst.completeNextPart (missionName);
		}
		//If we update the player state, do it
		if (updatePlayerState) {
			PlayerProperties.inst.curState = updatedState;
		}
		//Update UI
		ObjectiveHandler.inst.UpdateUI ();
		//Destroy this if needed
		if(destroyOnHit) {
			Destroy (this.gameObject);
		}
	}
}
