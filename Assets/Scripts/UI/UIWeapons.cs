using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIWeapons : MonoBehaviour {
	
	public class weapon {
		public string name;
		public int damage;
		public Sprite img;
		public bool available;
		
		/// <summary>
		/// Initializes a food
		/// </summary>
		/// <param name="n">Name of the food</param>
		/// <param name="a">Amount of food </param>
		/// <param name="h">Healing amount</param>
		/// <param name="e">Energy amount</param>
		/// <param name="i">The Image</param>
		public weapon(string n, int d, Sprite i, bool a) {
			name = n;
			damage = d;
			img = i;
			available = a;
		}
	}
	
	public List<weapon> currentWeapons = new List<weapon>();

	public Text weaponUIText;

	public Sprite swordImg;
	public Sprite fireballImg;
	public Sprite bowImg;
	public Sprite magicImg;


	void Awake () {
		DontDestroyOnLoad (transform.gameObject);
		currentWeapons.Add (new weapon ("Sword", 2, swordImg, true));
		currentWeapons.Add (new weapon ("Fireball", 3, fireballImg, true));
		currentWeapons.Add (new weapon ("Bow", 4, bowImg, false));
		currentWeapons.Add (new weapon ("Magic", 5, magicImg, false));
		weaponUIText = GameObject.FindGameObjectWithTag ("WeaponUIText").GetComponent<Text>();
	}
	
	public void obtainWeapon(string name, int amount) {
		foreach (weapon w in currentWeapons) {
			if(w.name == name) {
				w.available = true;
			}
		}
	}
	
	public void Equip(string name) {
		foreach (weapon w in currentWeapons) {
			if(w.name == name) {
				if(w.available) {
					weaponUIText.text = w.name;
				}
			}
		}
	}
	
}
