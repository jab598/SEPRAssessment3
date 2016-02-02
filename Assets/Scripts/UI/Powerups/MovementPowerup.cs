using UnityEngine;
using System.Collections;

public class MovementPowerup : Powerup 
{
	private float _speedModifier = 1.1f;

	public MovementPowerup(string name, string description, Sprite sprite, bool available, float speedModifier) 
		: base(name, description, sprite, available)
	{
		Debug.Log ("Initialized");
		_speedModifier = speedModifier;
	}

	public override void Enabled ()
	{
		Debug.Log ("Called");
		GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement> ().speedModifier = _speedModifier;
	}
}
