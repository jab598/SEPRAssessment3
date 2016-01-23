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
			Vector3 cannonSpawn = this.transform.position;
			Vector3 dire = (PlayerProperties.Position - cannonSpawn);
			dire.Normalize();
			var angle = Quaternion.Euler (0, 0, Mathf.Atan2 (-dire.y, -dire.x) * Mathf.Rad2Deg);

			Rigidbody2D CBall = Instantiate (ball, cannonSpawn, angle) as Rigidbody2D;
			CBall.AddForce (dire * 200);
			timer = 0.5f;
		} else
		{
			timer -= Time.deltaTime; 
		}
	}
}