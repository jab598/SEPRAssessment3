using UnityEngine;
using System;

/// <summary>
/// Powerup.
/// </summary>
public class Powerup
{
	public string name;
	public string description;
	public Sprite img;
	public bool available;

	public Powerup(string name, string description, Sprite sprite, bool available) 
	{
		this.name = name;
		this.description = description;
		this.img = sprite;
		this.available = available;
	}

	//What to do to the player when the powerup first takes effect.
	public virtual void Enabled()
	{
	}

	//What to do to the player when the powerup stops taking effect.
	public virtual void Disabled()
	{
	}

	//What to do to the player continuously while the powerup is enabled.
	public virtual void PlayerUpdate ()//GameObject player)
	{
	}
	
}


