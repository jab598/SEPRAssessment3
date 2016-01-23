using UnityEngine;
using System.Collections;

public class ShakeOnAwake : MonoBehaviour {

	public float amount = 2.0f;


	void Awake()
	{
		Camera.main.SendMessageUpwards ("ShakeWithIntensity", amount);
	}

}
