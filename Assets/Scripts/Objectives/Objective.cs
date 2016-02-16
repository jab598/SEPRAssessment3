using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/*
 * 
 * All new code
 * 
 * */

public class Objective {

	/// <summary>
	/// Name of the objective
	/// </summary>
	public string name;

	/// <summary>
	/// Is the obbjective complete
	/// </summary>
	public bool complete = false;

	public int currentStage = 0;

	/// <summary>
	/// <String,Bool> dictionary of parts of the mission.
	/// When all values are true, the mission is complete.
	/// </summary>
	public Dictionary<string,bool> parts = new Dictionary<string,bool> ();

	//Initialise
	public Objective(string nm) {
		name = nm;
		ObjectiveHandler.inst.UpdateUI ();
	}

	void Awake() {

	}

	/// <summary>
	/// Completes the next part of this objective
	/// </summary>
	public void completeNextPart() {
		string[] keyList = parts.Keys.ToArray ();
		foreach (string s in keyList) {
			Debug.Log ("looking up part " + s);
			if(parts[s] == false) {
				Debug.Log ("Part " + s + " was false; setting to true");
				parts[s] = true;
				Debug.Log ("Part " + s + " now is " + parts[s]);
				checkComplete();
				break;
			}
		}/*
		Debug.Log ("All parts: ");
		foreach(bool b in parts.Values) {
			Debug.Log (b);
		}*/
		ObjectiveHandler.inst.UpdateUI ();
	}

	/// <summary>
	/// checks if the objective is complete
	/// </summary>
	public void checkComplete() {
		if (!parts.ContainsValue (false)) {
			complete = true;
			Debug.Log (name + " completed");
			PlayerProperties.inst.Score += 100;
		}
		ObjectiveHandler.inst.UpdateUI ();
	}

	/// <summary>
	/// adds a part to the objective
	/// </summary>
	/// <param name="s">Name of the part.</param>
	/// <param name="c">If set to <c>true</c> , the part is already complete.</param>
	public void addPart(string s, bool c = false) {
		if (!parts.ContainsKey (s)) {
			parts [s] = c;
		}
		ObjectiveHandler.inst.UpdateUI ();
	}

	/// <summary>
	/// Completes a specific part of the objective.
	/// </summary>
	/// <param name="s">Part to complete.</param>
	public void completePart(string s) {
		if (parts.ContainsKey (s)) {
			parts [s] = true;
			currentStage++;
			checkComplete();
		} else {
			Debug.Log ("The part " + s + " does not exist in the mission " + name);
		}
		ObjectiveHandler.inst.UpdateUI ();
	}

}
