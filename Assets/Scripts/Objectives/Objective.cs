using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Objective : MonoBehaviour {

	/// <summary>
	/// Name of the objective
	/// </summary>
	public string name;

	/// <summary>
	/// Is the obbjective complete
	/// </summary>
	public bool complete = false;

	/// <summary>
	/// <String,Bool> dictionary of parts of the mission.
	/// When all values are true, the mission is complete.
	/// </summary>
	public Dictionary<string,bool> parts;

	//Initialise
	public Objective(string nm) {
		name = nm;
	}

	/// <summary>
	/// Completes the next part of this objective
	/// </summary>
	public void completeNextPart() {
		foreach(string s in parts.Keys) {
			if(parts[s] == false) {
				parts[s] = true;
				break;
			}
		}
	}

	/// <summary>
	/// checks if the objective is complete
	/// </summary>
	public void checkComplete() {
		if (!parts.ContainsValue (false)) {
			complete = true;
		}
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
	}

	/// <summary>
	/// Completes a specific part of the objective.
	/// </summary>
	/// <param name="s">Part to complete.</param>
	public void completePart(string s) {
		if (parts.ContainsKey (s)) {
			parts [s] = true;
			checkComplete();
		} else {
			Debug.Log ("The part " + s + " does not exist in the mission " + name);
		}
	}

}
