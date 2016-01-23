using UnityEngine;
using System.Collections;

public class Fireball : Weapon {

	public float fireballSpeed;


	// Use this for initialization
	void Start () {
		if (this.GetComponent<Rigidbody2D> () == null) {
			this.gameObject.AddComponent<Rigidbody2D>();

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D c) {
		if (c.gameObject.GetComponent<SimpleHP> () != null) {
			c.gameObject.GetComponent<SimpleHP> ().alterHealth(-weaponDamage);
		}
	}
}
