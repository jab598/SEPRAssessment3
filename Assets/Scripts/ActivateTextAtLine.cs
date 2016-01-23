using UnityEngine;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour
{

	public TextAsset theText;

	public int startLine;
	public int endLine;



	// allows to destroy the dialogue detection area.
	// once the dialogue has been initiated.
	public bool destroyWhenActivated;

	//If this dialog should trigger an objective to be added.
	public bool assignObjective;

	//The objective to be added if assignObjective is true.
	public string assignObjectiveName;

	//If we complete an objective by having this dialog.
	public bool completeObjective;

	//The objective to be completed if comleteObjective is true.
	public string completeObjectiveName;

	public bool activateGameObject;

	public GameObject gameObjectToActivate;


	TextBoxManager textBoxManager;


	void Start () 
	{
		textBoxManager = TextBoxManager.Inst;
	}


	public void OnDialogFinishHandler()
	{
		if (activateGameObject)
		{
			gameObjectToActivate.SetActive (true);
		}


		if (destroyWhenActivated)
		{
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// finds the player's collider
		if (other.name == "Player")
		{
			textBoxManager.currentDialog = this;
			textBoxManager.ReloadScript (theText);
			textBoxManager.currentLine = startLine;
			textBoxManager.endAtLine = endLine;
			textBoxManager.EnableTextBox ();


		}
	}
}
