using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/*
 * 
 * Updated for SceneManager.SwitchScene
 * 
 * */

public class SceneSwitcher : MonoBehaviour 
{
	/// <summary>
	/// Scene we are switching to
	/// </summary>
	public string sceneName;

	/// <summary>
	/// The required state of the player.
	/// </summary>
	public string requiredPlayerState;

	void OnTriggerEnter2D(Collider2D other) 
	{
		//If player collides, save the name of this object
		//and change the scene.
		if (other.transform.tag == "Player") {
			if(PlayerProperties.inst.curState == requiredPlayerState || requiredPlayerState == "") {
				PlayerPrefs.SetString ("WarpName", gameObject.name);
				SceneManager.LoadScene (sceneName);
			}
		}
	}
}
