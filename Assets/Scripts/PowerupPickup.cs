using UnityEngine;
using System.Collections;

public class PowerupPickup : MonoBehaviour 
{

	public int powerupIndex = 0;
	public string setState;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		//when we hit a player, give them the powerup and change the current state of the player. then destroy the powerup.
		if (col.transform.tag == "Player")
		{
			if(powerupIndex != null) {
				col.gameObject.GetComponent<Powerups>().EnablePowerup(powerupIndex);
			}
			if(setState != "") {
				col.gameObject.GetComponent<PlayerProperties>().curState = setState;
			}
			Destroy (gameObject);
		}
	}
}
