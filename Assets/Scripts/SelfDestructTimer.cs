using UnityEngine;
using System.Collections;

public class SelfDestructTimer : MonoBehaviour {

	public float timeInSeconds = 10.0f;

	float elapsed = 0;

	void Update () 
	{
		elapsed += Time.deltaTime;

		if (elapsed > timeInSeconds)
		{
			Destroy(gameObject);
		}
	}
}
