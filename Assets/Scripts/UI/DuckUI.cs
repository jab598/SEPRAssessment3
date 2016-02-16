using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DuckUI : MonoBehaviour {

	/// <summary>
	/// The width of the max health bar.
	/// </summary>
	public float maxHealthBarWidth = 165;

	/// <summary>
	/// The max health.
	/// </summary>
	public int maxHealth = 100;

	/// <summary>
	/// The health bar background.
	/// </summary>
	public RectTransform healthBarBackground;

	/// <summary>
	/// The health bar text.
	/// </summary>
	public GameObject healthBarText;

	/// <summary>
	/// The health text prefix.
	/// </summary>
	public string healthPrefix = "Health: ";

	int health;

	void Start () {
		AddHealth (0);
	}

	void Update () {
		//testings
		/*
		if (Input.GetKey (KeyCode.U)) {
			AddHealth (5);
		}
		if(Input.GetKey(KeyCode.I)) {
			AddHealth (-5);
		}*/
	}

	/// <summary>
	/// Adds some health.
	/// </summary>
	/// <param name="amount">Amount to add.</param>
	void AddHealth (int amount) 
	{
		SetHealth (health + amount);
	}

	/// <summary>
	/// Sets the health.
	/// </summary>
	/// <param name="amount">new health.</param>
	public void SetHealth(int amount)
	{
		health = Mathf.Clamp (amount, 0, maxHealth);
		UpdateVisuals ();
	}

	/// <summary>
	/// Updates the UI.
	/// </summary>
	void UpdateVisuals()
	{
		Vector3 newScale = healthBarBackground.sizeDelta;
		newScale.x = Mathf.Clamp(maxHealthBarWidth/maxHealth*health, 0, maxHealthBarWidth);
		healthBarBackground.sizeDelta = newScale;
		healthBarText.GetComponent<Text>().text = healthPrefix + health.ToString ();
		healthBarBackground.GetComponent<Image> ().color = new Color (1 - ((float)(health)/maxHealth), ((float)(health)/maxHealth), 0, 1);

	}

}
