using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DuckUI : MonoBehaviour {

	public float maxHealthBarWidth = 165;
	public int maxHealth = 100;
	public RectTransform healthBarBackground;
	public GameObject healthBarText;
	public string healthPrefix = "Health: ";

	int health;

	void Start () {
		AddHealth (0);
	}

	void Update () {
		//testings
		if (Input.GetKey (KeyCode.U)) {
			AddHealth (5);
		}
		if(Input.GetKey(KeyCode.I)) {
			AddHealth (-5);
		}
	}

	void AddHealth (int amount) 
	{
		SetHealth (health + amount);
	}

	public void SetHealth(int amount)
	{
		health = Mathf.Clamp (amount, 0, maxHealth);
		UpdateVisuals ();
	}

	void UpdateVisuals()
	{
		Vector3 newScale = healthBarBackground.sizeDelta;
		newScale.x = Mathf.Clamp(maxHealthBarWidth/maxHealth*health, 0, maxHealthBarWidth);
		healthBarBackground.sizeDelta = newScale;
		healthBarText.GetComponent<Text>().text = healthPrefix + health.ToString ();
		healthBarBackground.GetComponent<Image> ().color = new Color (1 - ((float)(health)/maxHealth), ((float)(health)/maxHealth), 0, 1);

	}

}
