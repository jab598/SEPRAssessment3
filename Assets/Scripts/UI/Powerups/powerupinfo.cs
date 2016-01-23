using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class powerupinfo : MonoBehaviour {

	public string hoverText;
	public Text textObject;

	public void mouseEnter() {
		textObject.gameObject.SetActive (true);
		textObject.text = hoverText;
	}

	public void mouseExit() {
		textObject.gameObject.SetActive (false);
	}

}
