using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*
 *
 * Added comments
 * 
 * */

public class Menu : MonoBehaviour {

	/// <summary>
	/// The entire menu panel
	/// </summary>
	public GameObject menuPanel;

	/// <summary>
	/// The backpack panel.
	/// </summary>
	public GameObject backpackPanel;

	/// <summary>
	/// The settings panel.
	/// </summary>
	public GameObject settingsPanel;

	/// <summary>
	/// The food panel.
	/// </summary>
	public GameObject foodPanel;

	/// <summary>
	/// The weapon panel.
	/// </summary>
	public GameObject weaponPanel;

	/// <summary>
	/// The powerup panel.
	/// </summary>
	public GameObject powerupPanel;

	/// <summary>
	/// Parent object to all the powerup sprite objecst
	/// </summary>
	public GameObject powerupSpriteHolder;

	/// <summary>
	/// The menu button.
	/// </summary>
	public GameObject menuButton;

	/// <summary>
	/// The volume slider.
	/// </summary>
	public Slider volumeSlider;

	/// <summary>
	/// The difficulty slider.
	/// </summary>
	public Slider difficultySlider;

	//Internal flags
	bool menuOpen = false;
	bool backpackOpen = false;
	bool settingsOpen = false;
	bool foodOpen = false;
	bool weaponOpen = false;
	bool powerupOpen = false;


	//Food
	/// <summary>
	/// Players food holder
	/// </summary>
	public UIFood food;

	/// <summary>
	/// Food name txet
	/// </summary>
	public Text nameText;

	/// <summary>
	/// Food energy text
	/// </summary>
	public Text energyText;

	/// <summary>
	/// Food healing amount text
	/// </summary>
	public Text healthText;

	/// <summary>
	/// Food amount text
	/// </summary>
	public Text amountText;

	/// <summary>
	/// The food image.
	/// </summary>
	public Image foodImage;

	//weapons
	/// <summary>
	/// Players weapons obj
	/// </summary>
	public UIWeapons weapons;

	/// <summary>
	/// The weapon name text holder
	/// </summary>
	public Text weaponNameText;

	/// <summary>
	/// The weapon damage text holder
	/// </summary>
	public Text weaponDamageText;

	/// <summary>
	/// The weapon available text holder
	/// </summary>
	public Text weaponAvailableText;

	/// <summary>
	/// The weapon image.
	/// </summary>
	public Image weaponImage;


	//powerups
	/// <summary>
	/// Players powerups holder
	/// </summary>
	public Powerups powerups;

	//Used to cycle through weapons and food
	int currentFoodIndex = 0;
	int currentWeaponIndex = 0;

	bool initial = false;

	// Use this for initialization
	void Start () {
		//Initialis the food, weapons and powerups vars, then update all UI.
		food = GameObject.FindGameObjectWithTag ("Statics").GetComponent<UIFood> ();
		weapons = GameObject.FindGameObjectWithTag ("Statics").GetComponent<UIWeapons> ();
		powerups = GameObject.FindGameObjectWithTag ("Statics").GetComponent<Powerups> ();
		updateFoodUI ();
		updateWeaponUI ();
		updatePowerupGUI ();
		ObjectiveHandler.inst.UpdateUI ();
		//Object.DontDestroyOnLoad (transform.gameObject);
	}


	private void LoadSettings()
	{
		difficultySlider.value = PlayerProperties.inst.DificultyLevel;
	}

	// Update is called once per frame
	void LateUpdate () {
		//When menu button pressed, toggle the menu
		if (Input.GetButtonDown ("Menu")) {
			if (menuOpen == false) {
				LoadSettings();
				openMenuPanel ();
			} else {
				closeMenuPanel();
			}
		}
	}

	/// <summary>
	/// Opens the menu.
	/// </summary>
	public void openMenuButton () {
		if (menuOpen == false) {
			openMenuPanel ();
		} else {
			closeMenuPanel();
		}
	}

	/// <summary>
	/// Opens the menu panel.
	/// </summary>
	public void openMenuPanel() {
		menuPanel.SetActive (true);
		menuOpen = true;
		menuButton.SetActive (false);
		PauseManager.Pause ();

	}

	/// <summary>
	/// Closes the menu panel.
	/// </summary>
	public void closeMenuPanel() {
		menuPanel.SetActive (false);
		menuOpen = false;
		menuButton.SetActive (true);
		closeBackpack ();
		closeSettings ();
		closeFood ();
		closeWeapons ();
		closePowerups ();
		PauseManager.Resume ();

	}

	/// <summary>
	/// Opens the backpack.
	/// </summary>
	public void openBackpack(){
		backpackPanel.SetActive (true);
		backpackOpen = true;
		closeSettings ();
	}

	/// <summary>
	/// Closes the backpack.
	/// </summary>
	public void closeBackpack(){
		backpackPanel.SetActive (false);
		foodPanel.SetActive (false);
		backpackOpen = false;
		closeFood ();
		closePowerups ();
		closeWeapons ();

	}

	/// <summary>
	/// Opens the settings.
	/// </summary>
	public void openSettings() {
		settingsPanel.SetActive (true);
		settingsOpen = true;
		closeBackpack ();
		closeWeapons ();
		closeFood ();
		closePowerups ();
	}

	/// <summary>
	/// Closes the settings.
	/// </summary>
	public void closeSettings(){
		settingsPanel.SetActive (false);
		settingsOpen = false;
	}

	/// <summary>
	/// When the volume slider is changed:
	/// </summary>
	public void volumeChanged(){
		AudioListener.volume = volumeSlider.value;
	}

	/// <summary>
	/// When the difficulty slider is changed
	/// </summary>
	public void DiffucultyChanged()
	{
		PlayerProperties.inst.DificultyLevel = (int)difficultySlider.value;
	}

	/// <summary>
	/// Exits the game.
	/// </summary>
	public void exitGame () {
		Application.Quit ();
	}

	/// <summary>
	/// Opens the food panel
	/// </summary>
	public void openFood(){
		foodPanel.SetActive (true);
		foodOpen = true;
		closeSettings ();
		closeWeapons ();
		closePowerups ();
	}

	/// <summary>
	/// Closes the food panel
	/// </summary>
	public void closeFood(){
		foodPanel.SetActive (false);
		foodOpen = false;

	}

	/// <summary>
	/// Cycle to the next food
	/// </summary>
	public void nextFood() {
		currentFoodIndex += 1;
		if (currentFoodIndex > food.currentFoods.Count -1) {
			currentFoodIndex = food.currentFoods.Count-1;
		}
		updateFoodUI ();
	}

	/// <summary>
	/// cycle to the previous food
	/// </summary>
	public void prevFood() {
		currentFoodIndex -= 1;
		if (currentFoodIndex < 0) {
			currentFoodIndex = 0;
		}
		updateFoodUI ();
	}

	/// <summary>
	/// Updates the food U.
	/// </summary>
	void updateFoodUI() {
		nameText.text = food.currentFoods [currentFoodIndex].name;
		energyText.text = "Energy: " + food.currentFoods [currentFoodIndex].energy.ToString ();
		healthText.text = "Health: " + food.currentFoods [currentFoodIndex].healAmount.ToString ();
		amountText.text = "X" + food.currentFoods [currentFoodIndex].amount.ToString ();
		foodImage.sprite = food.currentFoods [currentFoodIndex].img;
	}

	/// <summary>
	/// Eats currently selected food
	/// </summary>
	public void eatFood() {
		food.Eat (food.currentFoods [currentFoodIndex].name);
		updateFoodUI ();
	}

	/// <summary>
	/// Opens the weapons panel
	/// </summary>
	public void openWeapons(){
		weaponPanel.SetActive (true);
		weaponOpen = true;
		closeSettings ();
		closeFood ();
		closePowerups ();
	}
	/// <summary>
	/// Closes the weapons panel
	/// </summary>
	public void closeWeapons(){
		weaponPanel.SetActive (false);
		weaponOpen = false;
		
	}
	/// <summary>
	/// Cycle to next weapon
	/// </summary>
	public void nextWeapon() {
		currentWeaponIndex += 1;
		if (currentWeaponIndex > weapons.currentWeapons.Count -1) {
			currentWeaponIndex = weapons.currentWeapons.Count-1;
		}
		updateWeaponUI ();
	}

	/// <summary>
	/// Cycle to prev weapon
	/// </summary>
	public void prevWeapon() {
		currentWeaponIndex -= 1;
		if (currentWeaponIndex < 0) {
			currentWeaponIndex = 0;
		}
		updateWeaponUI ();
	}

	/// <summary>
	/// Equips the weapon.
	/// </summary>
	public void equipWeapon () {
		weapons.Equip (weapons.currentWeapons [currentWeaponIndex].name);
	}

	/// <summary>
	/// Updates the weapon U.
	/// </summary>
	void updateWeaponUI() {
		weaponNameText.text = weapons.currentWeapons [currentWeaponIndex].name;
		weaponDamageText.text = "Damage: " + weapons.currentWeapons [currentWeaponIndex].damage.ToString ();
		weaponAvailableText.text = "Available: " + weapons.currentWeapons [currentWeaponIndex].available.ToString ();
		weaponImage.sprite = weapons.currentWeapons [currentWeaponIndex].img;
	}

	/// <summary>
	/// Opens the powerups panel.
	/// </summary>
	public void openPowerups(){
		powerupPanel.SetActive (true);
		powerupOpen = true;
		closeSettings ();
		closeFood ();
		closeWeapons ();
		updatePowerupGUI();
	}

	/// <summary>
	/// Closes the powerups panel
	/// </summary>
	public void closePowerups(){
		powerupPanel.SetActive (false);
		powerupOpen = false;
		
	}

	/// <summary>
	/// Updates the powerup GUI.
	/// Cycles through all powerups, re-colors image based on availability.
	/// </summary>
	void updatePowerupGUI () {
		int count = 0;
		foreach (Image i in powerupSpriteHolder.GetComponentsInChildren<Image>()) {
			i.sprite = powerups.allPowerups[count].img;
			i.gameObject.GetComponent<powerupinfo>().hoverText = powerups.allPowerups[count].description;
			if(powerups.allPowerups[count].available) {
				i.color = new Color(255,255,255,255);
			} else {
				i.color = new Color(0.4f,0.4f,0.4f,0.25f);
			}
			count ++;
		}
	}	
}
	