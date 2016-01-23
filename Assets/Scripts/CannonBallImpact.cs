using UnityEngine;
using System.Collections;

public class CannonBallImpact : MonoBehaviour {
	public float damage = 1.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (!coll.isTrigger)
		{
			Destroy (gameObject);
		}

		if (coll.gameObject.name == "Player")
		{
			coll.gameObject.SendMessage ("TakeDamage", damage);
			Destroy (gameObject);
		}
	}
}
