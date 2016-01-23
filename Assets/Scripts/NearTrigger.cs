using UnityEngine;
using System.Collections;

/// <summary>
/// Sends a message up the game object heirarchy when a game
/// object with name name enters the trigger area.
/// </summary>
public class NearTrigger : MonoBehaviour {

	public string name;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name.StartsWith(name)) 
		{
			this.gameObject.SendMessageUpwards ("Near" + name, other.gameObject);
		}
	}
}
