using UnityEngine;
using System.Collections;

public class CannonSpawn : MonoBehaviour 
{

	public float range = 50.0f;

	void Start () 
	{
		Vector3 rando = transform.position + new Vector3 (Random.Range (-range, range), Random.Range (-range, range), 0);
		GameObject cannon = Instantiate (Resources.Load ("Cannon"), rando, Quaternion.identity) as GameObject;
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (range*2.0f, range*2.0f, 1));
	}
}
