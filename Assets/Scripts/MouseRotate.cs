using UnityEngine;
using System.Collections;

public class MouseRotate : MonoBehaviour {

	public float speed = 8.0f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		var ourScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
		var direction = Input.mousePosition - ourScreenPosition; 

		var desiredAngle = Quaternion.Euler (new Vector3(0, 0, Mathf.Atan2 (direction.y,direction.x) * Mathf.Rad2Deg));
		transform.rotation = Quaternion.Lerp (transform.rotation, desiredAngle, Time.deltaTime*speed);

	}
}
