using UnityEngine;
using System.Collections;


/// <summary>
/// Food pickup.
/// 
/// Adds food to the players inventory and then destroys itself on collision.
/// </summary>
public class FoodPickup : MonoBehaviour 
{

	public string foodName = "Apple";

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.name == "Player")
		{
			GameObject.FindGameObjectWithTag("Statics").GetComponent<UIFood>().ObtainFood(foodName,1);
		}

		Destroy (gameObject);
	}
}
