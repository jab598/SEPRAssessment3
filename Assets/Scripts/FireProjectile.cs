using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public GameObject projectilePrefab;
	
	public bool mouseAim = true;

	public float speed = 200.0f;

	public float knockBackAmount = 0.4f;

	public Transform target;

	//The rigidbody to apply knockback to.
	public Rigidbody2D knockBackRigidBody;


	//Function to modify the projectile, can imagine it like the
	//strength of the spell.
	public string modifierName = "SetExplosionMagnitude";


	public void Fire(float modifierValue = 1.0f)
	{
		/*
		Vector3 finalTarget;
		if (mouseAim)
		{
			finalTarget = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		} 
		else
		{
			finalTarget = this.target.position;
		}
		 
		Vector3 direction3D =  this.transform.position - finalTarget; 
		Vector2 direction = new Vector2 (direction3D.x, direction3D.y);

		direction.Normalize();

		var angle = Quaternion.Euler (0, 0, Mathf.Atan2 (-direction.y, -direction.x) * Mathf.Rad2Deg);

		GameObject projectile = (GameObject)Instantiate (projectilePrefab, transform.position, angle);

		projectile.SendMessage (modifierName, modifierValue);

		var projectileRigidBody = projectile.GetComponent<Rigidbody2D> ();

		var projectileImpulseVector = -(direction * speed)*modifierValue;

		projectileRigidBody.AddForce (projectileImpulseVector, ForceMode2D.Impulse);


		var knockBackImpulseVector = CalculateKnockback (projectileImpulseVector, knockBackAmount);


		knockBackRigidBody.AddForce (knockBackImpulseVector , ForceMode2D.Impulse);*/

		Vector3 finalTarget = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		GameObject projectile = (GameObject)Instantiate (projectilePrefab, transform.position + transform.forward, transform.rotation);

		projectile.GetComponent<Rigidbody2D> ().velocity = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * speed;

	}

	Vector3 CalculateKnockback(Vector2 projectileImpulse, float knockBackScale)
	{
		var magnitude = projectileImpulse.magnitude;

		//Kmockback in opposite direction to projectilw;
		var direction = -projectileImpulse.normalized;

		//If the magnitude is less than one squaring it will make it smaller.
		magnitude = magnitude + 1.0f;

		//Square and take the one we added before.
		magnitude = magnitude * magnitude * 0.4f - 1.0f;

		return direction * magnitude * knockBackScale;

	}
}
