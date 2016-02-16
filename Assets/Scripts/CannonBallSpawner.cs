using UnityEngine;
using System.Collections;

public class CannonBallSpawner : MonoBehaviour {

	public Rigidbody2D ball ;
	public float timer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (timer <= 0.0f)
		{
			//ASSESSMENT3
			//removed playerproprtties.position call again
			Vector3 cannonSpawn = this.transform.position;
			//direction to the player
			Vector3 dire = (GameObject.FindGameObjectWithTag("Player").transform.position - cannonSpawn);
			dire.Normalize();
			//something from assessment2 that wasnt commented. dont know what it does but dont touch this
			var angle = Quaternion.Euler (0, 0, Mathf.Atan2 (-dire.y, -dire.x) * Mathf.Rad2Deg);
			//instantiate a cannonball and fire it at the player
			Rigidbody2D CBall = Instantiate (ball, cannonSpawn, angle) as Rigidbody2D;
			CBall.AddForce (dire * 200);
			timer = 0.5f;
		} else
		{
			timer -= Time.deltaTime; 
		}
	}
}