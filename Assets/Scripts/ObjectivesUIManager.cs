using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ObjectivesUIManager : MonoBehaviour 
{

	public Objectives playerObjectives;

	public Text textBox;


	void OnEnabled()
	{
		UpdateUI ();
	}

	public void UpdateUI()
	{
		string text = "";
		var objectives = playerObjectives.objectiveMap;

		foreach (KeyValuePair<string,bool> objective in objectives)
		{
			//E.G Make Tea : Completed
			text +=  objective.Key + " : " + (objective.Value ? " Completed " : " Incomplete ");
			text += "\n";
		}

		textBox.text = text;

	}
}
