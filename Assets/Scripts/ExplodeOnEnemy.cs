using UnityEngine;
using System.Collections;

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
		GameObject explosion = (GameObject)Instantiate (Resources.Load ("FireExplosion"));
		explosion.transform.position = this.transform.position;
		explosion.SendMessage ("MakeExplosionForce", explosionMagnitude);

		Destroy (gameObject);
	}

}
