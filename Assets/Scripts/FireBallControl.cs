using UnityEngine;
using System.Collections;


/// <summary>
/// Fire ball control.
/// 
/// Gets the user input and uses it to control the fireball firing.
/// 
/// Fireballs can be held and charged.
/// Also provides audio feedback on how charged the fireball is.
/// 
/// </summary>
public class FireBallControl : MonoBehaviour
{

	float heldTime = 0.0f;

	public float fullChargeTime = 1.5f;

	public float fullChargeStrength = 3.0f;

	static string buttonName = "Fire1";

	public GameObject normalFireBall;
	public GameObject fullyChargedFireBall;

	public AudioSource fireSoundSource;
	public AudioSource chargeSoundSource;

	//Low pass the charging sound to make the sound change
	//as we charge the weapon.
	public AudioLowPassFilter chargeLowPass;
	public float startFrequency = 400f;
	public float finishFrequency = 5000f;

	FireProjectile _projectileLauncher;

	bool held = false;

	void Start() 
	{
		_projectileLauncher = gameObject.GetComponent<FireProjectile> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (!PauseManager.Paused)
		{
			GetInput();
			UpdateState();
		}
	}

	void GetInput()
	{
		
		if(Input.GetButtonDown(buttonName))
		{
			held = true;
		}
		if (Input.GetButtonUp (buttonName))
		{
			
			//Fire a fireball.
			Release(heldTime);
			fireSoundSource.Play();
			held = false;
			heldTime = 0.0f;
		}

	}

	void UpdateState()
	{
		if (held)
		{
			chargeSoundSource.enabled = true;
			
			heldTime += Time.deltaTime;
			float percentageCharged = Mathf.Clamp (heldTime / fullChargeTime, 0f, 1f);
			
			//Low pass goes from start to finish frequency based on percentage charged.
			chargeLowPass.cutoffFrequency = startFrequency + percentageCharged * (finishFrequency - startFrequency);
		} 
		else
		{
			chargeSoundSource.enabled = false;
		}
		
	}


	void Release(float heldTime)
	{
		float percentCharge = heldTime / fullChargeTime;


		if (percentCharge >= 1.0f)
		{
			//Fully charged so use special prefab.
			_projectileLauncher.projectilePrefab = fullyChargedFireBall;
		} 
		else
		{
			_projectileLauncher.projectilePrefab = normalFireBall;
		}

		//Clamp strength to max charge strength.
		float strength = Mathf.Clamp (percentCharge * fullChargeStrength, 1, fullChargeStrength);


		_projectileLauncher.Fire (strength);
		//Camera.main.SendMessageUpwards ("ShakeWithIntensity", 1.0f);
	}
}
