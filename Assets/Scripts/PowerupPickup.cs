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
			//Changed to include GetComponent
			if(powerupIndex != null) {
				GameObject.FindGameObjectWithTag("Statics").GetComponent<Powerups>().EnablePowerup(powerupIndex);
			}
			if(setState != "") {
				PlayerProperties.inst.curState = setState;
			}
			Destroy (gameObject);
		}
	}
}
