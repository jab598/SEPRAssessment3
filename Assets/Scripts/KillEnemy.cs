using UnityEngine;
using System.Collections;


/// <summary>
/// KillEnemy.
/// 
/// Send a hit and knockback message to the enemy when we collide with them.
/// </summary>
public class KillEnemy : MonoBehaviour 
{
	//Do we need to be going fast to kill them?
	public float minimumVelocity = 200.0f;

	private Vector3 _lastPosition;
	private Vector3 _velocity;

	private Rigidbody2D _rigidBody;
	private SpriteRenderer _renderer;
	public float knockBackAmount = 1.0f;


	
	void Start () 
	{
		_rigidBody = GetComponent<Rigidbody2D> ();
		_lastPosition = transform.position;
		_renderer = GetComponent<SpriteRenderer> ();
	}

	void Update () 
	{

		//Instantaneous velocity.
		_velocity = (transform.position - _lastPosition) / Time.deltaTime;

		_lastPosition = transform.position;
	}



	void OnTriggerEnter2D(Collider2D other) 
	{
		if (_velocity.magnitude > minimumVelocity) 
		{
			other.SendMessage ("Hit", SendMessageOptions.DontRequireReceiver);
			other.SendMessage ("KnockBack", new KnockBackArgs(transform.position,knockBackAmount), SendMessageOptions.DontRequireReceiver);
		}

	}
}
