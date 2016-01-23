using UnityEngine;
using System.Collections;

/// <summary>
/// Add objective on start.
/// 
/// </summary>
public class AddObjectiveOnStart : MonoBehaviour 
{

	public string name;
	public float delay = 2.0f;


	void Start ()
	{
		Timer.New (gameObject, delay, () =>
		{
			Objectives.Inst.AddObjective (name);
		});

	}
}
