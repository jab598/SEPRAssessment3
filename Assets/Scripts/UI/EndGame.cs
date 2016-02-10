using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	public Button endGameButton;
	public Text endGamePointsText;

	// Use this for initialization
	void Start () {
		endGamePointsText.text = PlayerProperties.inst.Score.ToString();
		Destroy (GameObject.FindGameObjectWithTag ("Statics"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndGameButtonPressed() {
		Application.Quit ();
	}
}
