using UnityEngine;
using System.Collections;

public class ProtectionPowerup : Powerup {


	private float _protection;

	/// <summary>
	/// Initializes a new instance of the <see cref="ProtectionPowerup"/> class.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="description">Description.</param>
	/// <param name="sprite">Sprite.</param>
	/// <param name="available">If set to <c>true</c>  powerup is available.</param>
	/// <param name="protection">Protection amount.</param>
	public ProtectionPowerup(string name, string description, Sprite sprite, bool available, float protection) 
		: base(name, description, sprite, available)
	{
		_protection = protection;
	}

	public override void Enabled ()
	{
		PlayerProperties.inst.protectionAmount += _protection;
	}
}
