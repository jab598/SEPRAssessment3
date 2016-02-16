using UnityEngine;
using System.Collections;

public class MovementPowerup : Powerup 
{
	private float _speedModifier;

	/// <summary>
	/// Initializes a new instance of the <see cref="MovementPowerup"/> class.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="description">Description.</param>
	/// <param name="sprite">Sprite.</param>
	/// <param name="available">If set to <c>true</c> powerup is available.</param>
	/// <param name="speedModifier">Speed modifier.</param>
	public MovementPowerup(string name, string description, Sprite sprite, bool available, float speedModifier) 
		: base(name, description, sprite, available)
	{
		Debug.Log ("Initialized");
		_speedModifier = speedModifier;
	}

	public override void Enabled ()
	{
		Debug.Log ("Called");
		GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement> ().speedModifier *= _speedModifier;
	}
}
