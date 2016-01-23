using UnityEngine;
using System.Collections;

public class ShockwaveSizeInterface : MonoBehaviour 
{

	//Conversion from unity unit radius to startSize for this effect.
	float sizeMultiplier = 3.3333f;

	void SetSize(float radius)
	{
		var particles = gameObject.GetComponent<ParticleSystem> ();

		particles.startSize = radius*sizeMultiplier;
	}
}
