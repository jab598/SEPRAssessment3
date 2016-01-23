using UnityEngine;
using System.Collections;

public class HideCursorOnEnable : MonoBehaviour 
{

	void OnEnable()
	{
		Cursor.visible = false;
	}

	void OnDisable()
	{
		Cursor.visible = true;
	}
}
