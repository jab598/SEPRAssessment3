using UnityEngine;
using System.Collections;

//Assessment3
//Optimised this a lot. No need to re-assign particles each time?
//Also, why this class exists we will never know.
//Unity was throwing some ~5000 errors per second.
//Would delete class, but if they take-over this project again it may be needed.

public class ShockwaveSizeInterface : MonoBehaviour 
{

	ParticleSystem particles;
	//Conversion from unity unit radius to startSize for this effect.
	void Start() {
		particles = gameObject.GetComponent<ParticleSystem> ();
	}

	float sizeMultiplier = 3.3333f;

	void SetSize(float radius)
	{
		particles.startSize = 1+radius*sizeMultiplier;
	}
}
