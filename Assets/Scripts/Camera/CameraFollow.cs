using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public  float defaultCameraSize = 124f;

	private float minimumDistanceX = 20.0f;
	private float minimumDistanceY = 5.0f;

	private float trackSpeedX = 1.0f;
	private float trackSpeedY = 2.0f;

	Camera _camera;

	// Use this for initialization
	void Start () 
	{
		_camera = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{

		float zoom =  _camera.orthographicSize/ defaultCameraSize;



		Vector3 newPosition = transform.position;

		Vector3 targetDisplacement = target.position - transform.position;



		if (Mathf.Abs(targetDisplacement.x) > minimumDistanceX*zoom)
		{
			newPosition.x = Mathf.Lerp (transform.position.x, target.position.x, (Time.deltaTime*trackSpeedX)/zoom);
		}

		if (Mathf.Abs(targetDisplacement.y) > minimumDistanceY*zoom)
		{
			newPosition.y = Mathf.Lerp (transform.position.y, target.position.y, (Time.deltaTime*trackSpeedY)/zoom);
		}

	    
		transform.position = newPosition;
		
	}

	public void SetTarget(Transform target)
	{
		this.target = target;
	}
}
