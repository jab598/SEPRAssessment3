using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {

	/// <summary>
	/// The end game button.
	/// </summary>
	public Button endGameButton;

	/// <summary>
	/// The end game points text.
	/// </summary>
	public Text endGamePointsText;

	// Use this for initialization
	void Start () {
		endGamePointsText.text = PlayerProperties.inst.Score.ToString();
		Destroy (GameObject.FindGameObjectWithTag ("Statics"));
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EndGameButtonPressed() {
		Application.Quit ();
	}
}
