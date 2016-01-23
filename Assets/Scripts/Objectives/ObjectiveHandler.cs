﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour {

	//Singleton method. use ObjectHandler.instance.[etc]
	private static ObjectiveHandler inst = null;
	public static ObjectiveHandler instance {
		get {
			if (inst == null) {
				inst =  FindObjectOfType(typeof (ObjectiveHandler)) as ObjectiveHandler;
			}
			return inst;
		}
	}

	public Text objectiveText;

	/// <summary>
	/// List of objectives
	/// </summary>
	public List<Objective> objectives = new List<Objective> ();

	//called before Start(), before the scene loads
	void Awake() {
		//persist between scenes
		Object.DontDestroyOnLoad (transform.gameObject);
		UpdateUI ();
	}

	// Use this for initialization
	void Start () {
		//build the mission library
		/*
		Objective tubeObj = new Objective ("getTube");
		tubeObj.addPart ("collectTube");
		tubeObj.addPart ("returnTube");
		objectives.Add (tubeObj);
		Debug.Log ("Started objective handler");*/
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
		UpdateUI ();
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
		UpdateUI ();
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

	public void UpdateUI()
	{
		objectiveText = GameObject.FindGameObjectWithTag ("ObjectiveTextHolder").GetComponent<Text> ();
		string text = "";
		
		foreach (Objective o in objectives)
		{
			//E.G Make Tea : Completed
			text +=  o.name + " : " + (o.complete ? " Completed " : " Incomplete ");
			text += "\n";
		}
		
		objectiveText.text = text;
		
	}
}
