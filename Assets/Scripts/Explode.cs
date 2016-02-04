using UnityEngine;
using System.Collections;


/// <summary>
/// Explode.
/// 
/// Cause all entities in a radius to recieve an explosion force
/// and some damage.
/// </summary>
public class Explode : MonoBehaviour
{

	//How big each property is in relation to the explosion amount.
	public float radiusMultiplier = 15.0f;
	public float damageMultiplier = 1.0f;
	public float forceMultiplier  = 5500.0f;

	float radius;
	float damage;
	float force;


	public void MakeExplosionForce(float amount)
	{
		/*
		radius = amount * radiusMultiplier;
		damage = amount * damageMultiplier;
		force  = amount * forceMultiplier;

//		Camera.main.SendMessageUpwards ("ShakeWithIntensity", amount * 2.0f);


		//Set the graphic to the same size.
		gameObject.BroadcastMessage ("SetSize", radius, SendMessageOptions.DontRequireReceiver);
*/
		Vector3 pos = transform.position;

		Collider2D[] colliders = Physics2D.OverlapCircleAll (pos, radius);
		
		foreach (Collider2D collider in colliders)
		{
			collider.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
			/*
			Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
			
			if(rb != null)
			{
				rb.AddExplosionForce(force, pos, radius);
			}*/
		}


	}

	
	void OnDrawGizmos()
	{
		var color = Color.yellow;
		color.a = 0.4f;
		Gizmos.color = color;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
	
}
