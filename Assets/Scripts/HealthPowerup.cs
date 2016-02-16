using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {

	private float _healthBonusMultiplier;

	/// <summary>
	/// Initializes a new instance of the <see cref="HealthPowerup"/> class.
	/// </summary>
	/// <param name="name">Name.</param>
	/// <param name="description">Description.</param>
	/// <param name="sprite">Sprite.</param>
	/// <param name="available">If set to <c>true</c> powerup is available.</param>
	/// <param name="healthBonus">Health bonus.</param>
	public HealthPowerup(string name, string description, Sprite sprite, bool available, float healthBonus) 
		: base(name, description, sprite, available)
	{
		_healthBonusMultiplier = healthBonus;
	}

	public override void Enabled ()
	{
		PlayerProperties.inst.healthMultiplier += _healthBonusMultiplier;
	}
}
