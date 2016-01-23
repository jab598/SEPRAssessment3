using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Menu : MonoBehaviour {
	
	public GameObject menuPanel;
	public GameObject backpackPanel;
	public GameObject settingsPanel;
	public GameObject foodPanel;
	public GameObject weaponPanel;
	public GameObject powerupPanel;
	public GameObject powerupSpriteHolder;
	public GameObject menuButton;
	public GameObject objectives;
	public Slider volumeSlider;
	public Slider difficultySlider;
	bool menuOpen = false;
	bool backpackOpen = false;
	bool settingsOpen = false;
	bool foodOpen = false;
	bool weaponOpen = false;
	bool powerupOpen = false;


	//Food
	public UIFood food;
	public Text nameText;
	public Text energyText;
	public Text healthText;
	public Text amountText;
	public Image foodImage;

	//weapons
	public UIWeapons weapons;
	public Text weaponNameText;
	public Text weaponDamageText;
	public Text weaponAvailableText;
	public Image weaponImage;


	//powerups
	public Powerups powerups;
	
	int currentFoodIndex = 0;
	int currentWeaponIndex = 0;

	// Use this for initialization
	void Start () {
		updateFoodUI ();
		updateWeaponUI ();
		updatePowerupGUI ();
	}


	private void LoadSettings()
	{
		difficultySlider.value = PlayerProperties.Inst.DificultyLevel;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetButtonDown ("Menu")) {
			if (menuOpen == false) {
				LoadSettings();
				openMenuPanel ();
			} else {
				closeMenuPanel();
			}
		}
	}

	public void openMenuButton () {
		if (menuOpen == false) {
			openMenuPanel ();
		} else {
			closeMenuPanel();
		}
	}

	public void openMenuPanel() {
		//objectives.SetActive (true);
		//objectives.GetComponentInChildren<ObjectivesUIManager> ().UpdateUI ();
		menuPanel.SetActive (true);
		menuOpen = true;
		menuButton.SetActive (false);
		PauseManager.Pause ();

	}
	public void closeMenuPanel() {
		objectives.SetActive (false);
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
	public void openBackpack(){
		backpackPanel.SetActive (true);
		backpackOpen = true;
		closeSettings ();
	}
	public void closeBackpack(){
		backpackPanel.SetActive (false);
		foodPanel.SetActive (false);
		backpackOpen = false;
		closeFood ();
		closePowerups ();
		closeWeapons ();

	}
	public void openSettings() {
		settingsPanel.SetActive (true);
		settingsOpen = true;
		closeBackpack ();
		closeWeapons ();
		closeFood ();
		closePowerups ();
	}
	public void closeSettings(){
		settingsPanel.SetActive (false);
		settingsOpen = false;
	}


	public void volumeChanged(){
		AudioListener.volume = volumeSlider.value;
	}

	public void DiffucultyChanged()
	{
		PlayerProperties.Inst.DificultyLevel = (int)difficultySlider.value;
	}

	public void exitGame () {
		Application.Quit ();
	}

	public void openFood(){
		foodPanel.SetActive (true);
		foodOpen = true;
		closeSettings ();
		closeWeapons ();
		closePowerups ();
	}
	public void closeFood(){
		foodPanel.SetActive (false);
		foodOpen = false;

	}
	public void nextFood() {
		currentFoodIndex += 1;
		if (currentFoodIndex > food.currentFoods.Count -1) {
			currentFoodIndex = food.currentFoods.Count-1;
		}
		updateFoodUI ();
	}
	public void prevFood() {
		currentFoodIndex -= 1;
		if (currentFoodIndex < 0) {
			currentFoodIndex = 0;
		}
		updateFoodUI ();
	}
	
	void updateFoodUI() {
		nameText.text = food.currentFoods [currentFoodIndex].name;
		energyText.text = "Energy: " + food.currentFoods [currentFoodIndex].energy.ToString ();
		healthText.text = "Health: " + food.currentFoods [currentFoodIndex].healAmount.ToString ();
		amountText.text = "X" + food.currentFoods [currentFoodIndex].amount.ToString ();
		foodImage.sprite = food.currentFoods [currentFoodIndex].img;
	}

	public void eatFood() {
		food.Eat (food.currentFoods [currentFoodIndex].name);
		updateFoodUI ();
	}

	
	public void openWeapons(){
		weaponPanel.SetActive (true);
		weaponOpen = true;
		closeSettings ();
		closeFood ();
		closePowerups ();
	}
	public void closeWeapons(){
		weaponPanel.SetActive (false);
		weaponOpen = false;
		
	}
	public void nextWeapon() {
		currentWeaponIndex += 1;
		if (currentWeaponIndex > weapons.currentWeapons.Count -1) {
			currentWeaponIndex = weapons.currentWeapons.Count-1;
		}
		updateWeaponUI ();
	}
	public void prevWeapon() {
		currentWeaponIndex -= 1;
		if (currentWeaponIndex < 0) {
			currentWeaponIndex = 0;
		}
		updateWeaponUI ();
	}

	public void equipWeapon () {
		weapons.Equip (weapons.currentWeapons [currentWeaponIndex].name);
	}

	void updateWeaponUI() {
		weaponNameText.text = weapons.currentWeapons [currentWeaponIndex].name;
		weaponDamageText.text = "Damage: " + weapons.currentWeapons [currentWeaponIndex].damage.ToString ();
		weaponAvailableText.text = "Available: " + weapons.currentWeapons [currentWeaponIndex].available.ToString ();
		weaponImage.sprite = weapons.currentWeapons [currentWeaponIndex].img;
	}
	public void openPowerups(){
		powerupPanel.SetActive (true);
		powerupOpen = true;
		closeSettings ();
		closeFood ();
		closeWeapons ();
		updatePowerupGUI();
	}
	public void closePowerups(){
		powerupPanel.SetActive (false);
		powerupOpen = false;
		
	}
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
	