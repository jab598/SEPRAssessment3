using UnityEngine;
using System.Collections;


/// <summary>
/// Seeker AI
/// 
/// Moves towoards the target.
/// </summary>
public class SeekerAI : MonoBehaviour 
{
	
	private Transform _target;
	Rigidbody2D _rigidBody;
	public float speed = 2.0f;


	public SpriteRenderer spriteRenderer;
	public Sprite upSprite;
	public Sprite downSprite;
	public Sprite leftSprite;
	public Sprite rightSprite;
	string lastDirection = "";

	//How much we repel other enemies.
	public float repelance = 1.0f;

	//How close we get before we stop adding force.
	public float standOffDistance = 0.0f;

	// Use this for initialization
	void Start () 
	{
		_target = GameObject.FindGameObjectWithTag ("Player").transform;
		_rigidBody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		MoveToTarget ();
	}

	void MoveToTarget()
	{
		//Line from us to the target
		Vector3 joiningLine = _target.transform.position - transform.position;
		Vector2 joiningLine2D = new Vector2 (joiningLine.x, joiningLine.y);
		
		//Force in the direction of the joining line.
		Vector2 forceVector = joiningLine2D.normalized * speed * (PlayerProperties.inst.DificultyLevel + 1);

		string direction = Utils.MainDirectionString (joiningLine);

		if (direction != lastDirection)
		{
			switch (direction)
			{
				case "Up":
					spriteRenderer.sprite = upSprite;
					break;
				case "Down":
					spriteRenderer.sprite = downSprite;
					break;
				case "Left":
					spriteRenderer.sprite = leftSprite;
					break;
				case "Right":
					spriteRenderer.sprite = rightSprite;
					break;
			}
		}

		lastDirection = direction;

		
		if (joiningLine.magnitude > standOffDistance)
		{
			_rigidBody.AddForce (forceVector);
		}
	}

	public void NearEnemy(object enemy)
	{
		var enemyTransform = ((GameObject)enemy).transform;
		Vector3 distance = enemyTransform.position - transform.position;
		distance.Normalize ();

		//Repel self from enemy.
		_rigidBody.AddForce (-distance*repelance); 
	}

	//Added ASSESSMENT 3
	void OnCollisionEnter2D(Collision2D c) {
		if (c.transform.tag == "Player") {
			PlayerProperties.inst.TakeDamage (10);
			Destroy (this.gameObject);
		}
	}
	
}
