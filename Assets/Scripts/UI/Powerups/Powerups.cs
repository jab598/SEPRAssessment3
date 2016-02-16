using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Powerups.
/// Manages the powerups the player has enabled.
/// </summary>
public class Powerups : MonoBehaviour 
{

	public List<Powerup> allPowerups = new List<Powerup> ();
	public List<Powerup> enabledPowerups = new List<Powerup>();

	public Sprite run1Img;
	public Sprite run2Img;
	public Sprite run3Img;
	public Sprite health1Img;
	public Sprite health2Img;
	public Sprite health3Img;
	public Sprite prot1Img;
	public Sprite prot2Img;
	public Sprite prot3Img;
	public Sprite points1Img;
	public Sprite points2Img;
	public Sprite points3Img;
	
	void Awake () 
	{
		Object.DontDestroyOnLoad (this);
		allPowerups.Add (new MovementPowerup ("mv1", "Move 10% faster", run1Img, false, 1.1f));
		allPowerups.Add (new MovementPowerup ("mv2", "Move 20% faster", run2Img, false, 1.2f));
		allPowerups.Add (new MovementPowerup ("mv3", "Move 30% faster", run3Img, false, 1.3f));
		allPowerups.Add (new HealthPowerup ("hp1", "+10% Health", health1Img, false, 0.1f));
		allPowerups.Add (new HealthPowerup ("hp2", "+20% Health", health2Img, false, 0.1f));
		allPowerups.Add (new HealthPowerup ("hp3", "+30% Health", health3Img, false, 0.1f));
		allPowerups.Add (new Powerup ("pe2", "+25% Protection from Enemies", prot1Img, false));
		allPowerups.Add (new Powerup ("pe5", "+50% Protection from Enemies", prot2Img, false));
		allPowerups.Add (new Powerup ("imo", "Immortality", prot3Img, false));

		/*
		 * Removed points multiplier powerups as they are too overpowered compaired to the rest.
		allPowerups.Add (new Powerup ("dbl", "Double Point Collection", points1Img, false));
		allPowerups.Add (new Powerup ("trp", "Triple Point Collection", points2Img, false));
		allPowerups.Add (new Powerup ("qua", "Quadruple Point Collection", points3Img, false));
		*/
	}

	public void OnLevelWasLoaded() {
		//readds powerups at the start of each level.
		foreach (Powerup p in enabledPowerups)
		{
			p.Enabled();
		}
	}

	/// <summary>
	/// Enables the powerup.
	/// </summary>
	/// <param name="index">Index of powerup to activate.</param>
	public void EnablePowerup(int index)
	{
		//flag to add all powerups
		if (index == 1000) {
			enabledPowerups.Clear ();
			foreach (Powerup p in allPowerups) {
				p.available = true;
				p.Enabled ();
				enabledPowerups.Add (p);
			}
		} else {
			//else add the one weve asked for
			allPowerups [index].available = true;
			allPowerups [index].Enabled ();
			enabledPowerups.Add (allPowerups [index]);
		}
		//powerup.Enabled ();
		//enabledPowerups.Add (powerup);

		//FloatingTextManager.MakeFloatingText (transform, powerup.description, Color.blue, 2.0f);
	}

	/// <summary>
	/// Disables a powerup.
	/// </summary>
	/// <param name="name">Name of powerup.</param>
	public void DisablePowerup(string name)
	{
		var powerup = FindPowerup (name);
		powerup.available = false;
		powerup.Disabled ();
		enabledPowerups.Remove(powerup);
	}

	/// <summary>
	/// Finds a powerup.
	/// </summary>
	/// <returns>The powerup.</returns>
	/// <param name="name">Name of powerup.</param>
	public Powerup FindPowerup(string name)
	{
		foreach (Powerup p in allPowerups)
		{
			if(p.name == name)
			{
				return p;
			}
		}

		Debug.LogError ("Powerup " + name + " does not exist");
		return allPowerups[0];
	}

	void Update()
	{
		//Removed for performance issues. unconnditional loops in Update() are generally bad
		/*
		foreach (Powerup p in enabledPowerups)
		{
			p.PlayerUpdate(PlayerProperties.Player);
		}
		*/
	}
}
