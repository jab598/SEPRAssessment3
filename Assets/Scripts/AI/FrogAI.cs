using UnityEngine;
using System.Collections;

/// <summary>
/// FrogAI
/// 
/// Jumps to the player one hop at a time.
/// </summary>
public class FrogAI : MonoBehaviour 
{
	
	public string targetName = "Player";


	//How often we hop.
	public float hopPeriod = 1.5f;


	//How long it takes for one hop.
	public float hopTime = 1.0f;


	//How long between looking where the player is and hopping.
	public float hopLatency = 0.1f;

	//Range for one hop.
	public float range = 20.0f;

	public float stunTime = 0.5f;

	public GameObject particlePrefab;


	private Transform _target;

	public Animator animator;


	//Components
	private BoxCollider2D 	_boxCollider;
	private Explode 		_explodeScript;


	//Hop state info
	private float 	_elapsedSinceHop = 0.0f;
	private bool 	_hopping;

	private Vector3 hopTarget 			= new Vector2();
	private Vector3 positionBeforeHop 	= new Vector2();



	void Start () 
	{
		_target = GameObject.Find (targetName).transform;

	}

	void Awake()
	{
		_boxCollider = gameObject.GetComponent<BoxCollider2D> ();
		_explodeScript = gameObject.GetComponent<Explode> ();

	}
	
	
	void Update () 
	{
		
		//If we started before the player.
		if (_target == null) 
		{
			_target = GameObject.Find (targetName).transform;
		}


		UpdateHopState ();

	}

	void UpdateHopState()
	{

		_elapsedSinceHop += Time.deltaTime;

		//Look where the target is and store it early (so it is not perfectly accurate).
		if (_elapsedSinceHop > hopPeriod - hopLatency)
		{
			StoreTargetPosition ();
		}


		//Timer finished so start hopping.
		if (_elapsedSinceHop > hopPeriod)
		{
			StartHop ();
		}

		//If we are hopping this frame.
		if (_hopping)
		{

			//If the hop is finished
			if (_elapsedSinceHop > hopTime)
			{
				EndHop ();
			} 
			else
			{
				CalculateHopPosition ();
			}
		}

		//Only when we hit the ground do we want to collide.
		_boxCollider.isTrigger = _hopping;

	}


	
	void CalculateHopPosition()
	{
		//Line from beggining to end of hop.
		Vector3 hopLine = hopTarget - positionBeforeHop;

		float hopLineMagnitude = hopLine.magnitude;
		Vector3 hoplineDirection = hopLine.normalized;
		
		float percentageHopDone = _elapsedSinceHop / hopTime;

		//Where on the hopline are we based on how long into the hop we are.
		Vector3 newPosition = positionBeforeHop + hoplineDirection * hopLineMagnitude * percentageHopDone;


		//Frog is bigger when it hops higher due to perspective.
		//Scale is is the parabolic curve -x(x -1) + 1
		//       . .
		//     .     .
		//    .       .

		float scale = -percentageHopDone * (percentageHopDone - 1) + 1;
		transform.localScale = new Vector3 (scale, scale,transform.localScale.z);
		
		//Only move in 2D.
		newPosition.z = transform.position.z;
		
		transform.position = newPosition;
		
	}


	void StoreTargetPosition()
	{
		//Line from us to the target.
		Vector3 joiningLine = transform.position - _target.transform.position;


		if (joiningLine.magnitude < range)
		{
			//If we can get ther in one hop then do it.
			hopTarget = _target.transform.position;
		}
		else if (joiningLine.magnitude < range*3.0f)
		{
			//We can get there in less than 3 hops so
			//Move in the direction of the target at maximum hop distance.
			hopTarget = (_target.transform.position - transform.position).normalized * range;
		}
		else
		{
			//Wait.
		}


	}

	void StartHop()
	{
		_elapsedSinceHop = 0.0f;
		positionBeforeHop = transform.position;
		_hopping = true;

		Vector3 movementVector = _target.position - transform.position;

		animator.SetTrigger ("jump" + Utils.MainDirectionString (movementVector));
	}

	void EndHop()
	{
		//Pound the ground when we land.
		_explodeScript.MakeExplosionForce(1.0f);
		_hopping = false;
		_elapsedSinceHop = 0.0f;
	}


	//Debug
	void OnDrawGizmos()
	{
		Gizmos.DrawLine (transform.position, hopTarget);
		Gizmos.DrawWireSphere (transform.position, range);
	}


	//Slow the player on collide.
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.name == "Player")
		{
			collider.gameObject.SendMessage("Slow");
		}

	}

	//Recieve knockback.
	public void  KnockBack( KnockBackArgs args)
	{
		//Hop away
		hopTarget = transform.position + (transform.position - new Vector3(args.center.x,args.center.y)).normalized * args.magnitude;
		StartHop ();
	}


}
