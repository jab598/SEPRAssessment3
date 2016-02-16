using UnityEngine;
using System.Collections;

/// <summary>
/// Explode on enemy.
/// </summary>
public class ExplodeOnEnemy : MonoBehaviour 
{
	public float explosionMagnitude = 1.0f;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name.Contains ("Enemy"))
		{
			Explode();
		}
	}

	void SetExplosionMagnitude(float value)
	{
		explosionMagnitude = value;
	}

	void Explode()
	{
		//FIXED MAJOUR BUG HERE.
		//Instantiate(resource.load) doesnt sit well with unity
		//also, Instantiate has a position paramater, why they re-set it below
		//I will never know. 
		//Instantiate(obj); obj.pos = xxx     ->     Instantiate(obj, pos, rot).
		// /sigh
		GameObject expl = (GameObject)Resources.Load ("FireExplosion");
		GameObject explosion = (GameObject)Instantiate (expl, this.transform.position, Quaternion.identity);
		//explosion.transform.position = this.transform.position;

		//Send message is horrible.
		//Identifying where this message goes is almost impossible
		//Not going to tough it.
		explosion.SendMessage ("MakeExplosionForce", explosionMagnitude);

		Destroy (gameObject);
	}

}
