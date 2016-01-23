using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Objectives : MonoBehaviour 
{
	public Dictionary<string, bool> objectiveMap  { get; private set;}

	public static Objectives Inst;



	public Objectives()
	{
		Inst = this;
		objectiveMap = new Dictionary<string, bool>();
	}


	public void AddObjective(string name)
	{
		if (!objectiveMap.ContainsKey (name))
		{
			//FloatingTextManager.MakeFloatingText (transform, "New Objective: " + name, Color.white, 4.0f);
			objectiveMap.Add (name, false);
		}
	}


	public void CompleteObjective(string name)
	{
		if(objectiveMap.ContainsKey(name))
		{
			//FloatingTextManager.MakeFloatingText (transform, "Objective Complete!", Color.green);
			objectiveMap[name] = true;
		}
	}
}
