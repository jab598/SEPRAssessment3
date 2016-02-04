using UnityEngine;
using System.Collections;

/// <summary>
/// SimpleHP.
/// 
/// Keeps track of an HP and can recieve damage.
/// </summary>
public class SimpleHP : MonoBehaviour
{

	//public for inspector
	public float maxHealth = 20.0f;

	public float hitDamage = 1.0f;


	float health = 1.0f;

	public int pointsOnKill = 10;

	void Start()
	{
		health = maxHealth;
	}


	void Update () 
	{
		if (health <= 0)
		{
			PlayerProperties.inst.Score += pointsOnKill;
			Destroy(this.gameObject);
		}
	}

	//Take specific damage.
	public void TakeDamage(float amount)
	{
		health -= amount;
		FloatText (amount);
	}

	//Take damage based on our resitance.
	public void Hit()
	{
		health -= hitDamage;
		FloatText (hitDamage);
	}

	void FloatText(float amount)
	{
		if (amount != 0)
		{
			//FloatingTextManager.MakeFloatingText (transform, FloatingTextManager.FormatDamage (-amount), Color.green);
		}
	}

	public void alterHealth (int amount) {
		Debug.Log (this.gameObject.name + " took damage, health is now " + health);
		health = Mathf.Clamp (health + amount, 0, maxHealth);
	}	
}
