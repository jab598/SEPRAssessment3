using UnityEngine;
using System.Collections;

public class HealthPowerup : Powerup {

	private float _healthBonusMultiplier;

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
