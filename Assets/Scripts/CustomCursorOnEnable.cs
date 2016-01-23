using UnityEngine;
using System.Collections;

public class CustomCursorOnEnable : MonoBehaviour {

	public Texture2D cursorTexture;

	void OnEnable()
	{
		Cursor.visible = true;
		Cursor.SetCursor (cursorTexture, new Vector2 (cursorTexture.width/2.0f, cursorTexture.height/2.0f), CursorMode.ForceSoftware);
	}
	
	void OnDisable()
	{
		Cursor.visible = false;
	}
}
