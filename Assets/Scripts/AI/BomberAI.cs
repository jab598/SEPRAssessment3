using UnityEngine;
using System.Collections;

public class BomberAI : MonoBehaviour {

	string targetName = "Player";

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.name == targetName)
		{
			Explode();
		}
	}


	void Explode()
	{
		GameObject explosion = (GameObject)Instantiate (Resources.Load ("FireExplosion"));
		explosion.transform.position = this.transform.parent.position;
		this.SendMessageUpwards ("Die");

		explosion.SendMessage ("MakeExplosionForce");
	}
}
