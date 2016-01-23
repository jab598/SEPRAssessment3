using UnityEngine;
using System.Collections;

public static class Rigidbody2DExtensions
{

	// http://forum.unity3d.com/threads/need-rigidbody2d-addexplosionforce.212173/

	public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius)
	{
		var direction = (body.transform.position - explosionPosition);

		float wearoff = 1 - (direction.magnitude / explosionRadius);

		body.AddForce(direction.normalized * explosionForce * wearoff);
	}
	
	public static void AddExplosionForce(this Rigidbody2D body, float explosionForce, Vector3 explosionPosition, float explosionRadius, float upliftModifier)
	{
		var dir = (body.transform.position - explosionPosition);
		float wearoff = 1 - (dir.magnitude / explosionRadius);
		Vector3 baseForce = dir.normalized * explosionForce * wearoff;
		body.AddForce(baseForce);
		
		float upliftWearoff = 1 - upliftModifier / explosionRadius;
		Vector3 upliftForce = Vector2.up * explosionForce * upliftWearoff;
		body.AddForce(upliftForce);
	}
}