using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectiveHandler : MonoBehaviour {

	//Singleton method. use ObjectHandler.inst.[etc]
	private static ObjectiveHandler inst = null;
	public static ObjectiveHandler instance {
		get {
			if (inst == null) {
				inst =  FindObjectOfType(typeof (ObjectiveHandler)) as ObjectiveHandler;
			}
			return inst;
		}
	}

	/// <summary>
	/// The bio chem student object.
	/// </summary>
	public GameObject bioChemStudent;

	/// <summary>
	/// List of objectives
	/// </summary>
	public static List<Objective> objectives = new List<Objective> ();

	//called before Start(), before the scene loads
	void Awake() {
		//persist between scenes
		Object.DontDestroyOnLoad (transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		//build the mission library
		Objective coffeObj = new Objective ("getCoffee");;
		coffeObj.addPart ("collectCoffee");
		coffeObj.addPart ("returnCoffee");
		objectives.Add (coffeObj);

		Objective tubeObj = new Objective ("getTube");
		tubeObj.addPart ("collectTube");
		tubeObj.addPart ("returnTube");
		objectives.Add (tubeObj);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Completes the next part of the objective.
	/// </summary>
	/// <param name="objectiveName">Objective name.</param>
	public void completeNextPart(string objectiveName) {
		foreach (Objective o in objectives) {
			if(o.name == objectiveName) {
				o.completeNextPart();
			}
		}
	}

	/// <summary>
	/// Completes parts of an objective
	/// </summary>
	/// <param name="objectiveName">Objective name.</param>
	/// <param name="part">Part of the objecive.</param>
	public void completePart(string objectiveName, string part) {
		foreach (Objective o in objectives) {
			if(o.name == objectiveName) {
				o.completePart(part);
			}                        
		}
	}

	/// <summary>
	/// Checks if part of a mission is complete
	/// </summary>
	/// <returns><c>true</c>, if part was checked, <c>false</c> otherwise.</returns>
	/// <param name="objectiveName">Objective name.</param>
	/// <param name="objectivePart">Objective part.</param>
	public bool checkPart(string objectiveName, string objectivePart) {
		bool comp = false;
		foreach (Objective o in objectives) {
			if(o.name == objectiveName) {
				if(o.parts.ContainsKey(objectivePart)) {
					comp = o.parts[objectivePart];
					break;
				} else {
					Debug.Log (objectiveName + " does not contain part " + objectivePart) ;
				}
			}
		}
		return comp;
	}
}
