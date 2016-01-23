using UnityEngine;
using System.Collections;

public class PowerupPickup : MonoBehaviour 
{

	public string powerUpName = "mv1";
	public string setState;
	
	void OnTriggerEnter2D(Collider2D col)
	{
		//when we hit a player, give them the powerup and change the current state of the player. then destroy the powerup.
		if (col.transform.tag == "Player")
		{
			if(powerUpName != "") {
				col.gameObject.GetComponent<Powerups>().EnablePowerup(powerUpName);
			}
			if(setState != "") {
				PlayerProperties.Inst.curState = setState;
			}
		}
		
		Destroy (gameObject);
	}
}
