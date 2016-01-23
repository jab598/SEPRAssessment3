using UnityEngine;
using System.Collections;

public class DestroyOnDie : MonoBehaviour {

	void Die()
	{
		Destroy (gameObject);
	}
}
