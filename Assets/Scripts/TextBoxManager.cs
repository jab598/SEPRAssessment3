using UnityEngine;
using System.Collections;
using UnityEngine.UI; // allows to use Text type

public class TextBoxManager : MonoBehaviour {


	//Singleton Class.
	public static TextBoxManager Inst;


	public TextBoxManager()
	{
		Inst = this;
	}

	[HideInInspector]
	public ActivateTextAtLine currentDialog;


	// Holds text to display in a dialogue box
	[HideInInspector]
	public TextAsset textFile; 

	
	// Each line from the text file is taken 
	// into an array as a separate entity
	[HideInInspector]
	public string[] textlines; 
	


	// keeps of where in the text file we are
	[HideInInspector]
	public int currentLine;



	// allows to check if we reach the end of the text file
	[HideInInspector]
	public int endAtLine;

	[HideInInspector]
	public bool isActive;
	

	// used to decide if we want the player's movement to halt when
	//the dialogue is initiated
	public bool stopPlayerMovement;


	public GameObject textPanel;
	public Text guiText; 




	void Start ()
	{
		isActive = false;

		// Check if the text file exists
		if (textFile != null)
		{
			textlines = (textFile.text.Split('\n'));
			// Grabs text from "Text.txt" and splits it
			// into separate pieces whenever a newline
			// is encountered
		}

		if (endAtLine == 0)
		{
			endAtLine = textlines.Length - 1;
			// Guarding against reading text out ouf bounds
			// of the .txt file

		}

		if (isActive)
		{
			EnableTextBox ();
		} 
		else
		{
			DisableTextBox();
		}
	
	}

	void Update () 
	{

		if (!isActive)
		{
			// prevents the function from running
			// if the text box isn't being shown
			return;
		}

		guiText.text = textlines [currentLine];

		// if enter is pressed, move to the next part of the text
		if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
		{
			currentLine += 1;
		}

		// close the text box if all lines have been traversed
		if (currentLine > endAtLine)
		{
			DisableTextBox();

			currentDialog.OnDialogFinishHandler ();
		}
	}

	public void EnableTextBox()
	{

		isActive = true;

		textPanel.SetActive(true);

		if (stopPlayerMovement)
		{
			DisablePlayerMovement();
		}
	}

	public void DisableTextBox()
	{
		textPanel.SetActive(false);
		isActive = false;

		EnablePlayerMovement ();
	}

	void EnablePlayerMovement()
	{
		//PlayerProperties.Player.GetComponent<CharacterMovement> ().canMove = true;
		PauseManager.Resume();
	}

	void DisablePlayerMovement()
	{
		///PlayerProperties.Player.GetComponent<CharacterMovement> ().canMove = false;
		PauseManager.Pause();
	}

	public void ReloadScript(TextAsset theText)
	{

		// allows to use different text files within the game
		// for different dialogues

		if (theText != null)
		{
			// creates a fresh array holding new text
			textlines = new string[1];
			textlines = (theText.text.Split('\n'));
		}
	}

}

