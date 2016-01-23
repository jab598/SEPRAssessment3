using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIFood : MonoBehaviour {

	public class food {
		public string name;
		public int amount;
		public int healAmount;
		public int energy;
		public Sprite img;

		/// <summary>
		/// Initializes a food
		/// </summary>
		/// <param name="n">Name of the food</param>
		/// <param name="a">Amount of food </param>
		/// <param name="h">Healing amount</param>
		/// <param name="e">Energy amount</param>
		/// <param name="i">The Image</param>
		public food(string n, int a, int h, int e, Sprite i) {
			name = n;
			amount = a;
			healAmount = h;
			energy = e;
			img = i;
		}
	}

	public List<food> currentFoods = new List<food>();

	public Sprite appleImg;
	public Sprite berryImg;
	public Sprite breadImg;

	void Awake () {
		currentFoods.Add (new food ("Apple", 2, 50, 2, appleImg));
		currentFoods.Add (new food ("Berries", 30, 1, 3, berryImg));
		currentFoods.Add (new food ("Bread", 4, 10, 5, breadImg));
	}

	public void ObtainFood(string name, int amount) {
		foreach (food f in currentFoods) {
			if(f.name == name) {
				f.amount += amount;
			}
		}
	}
	
	public void Eat(string name) {
		foreach (food f in currentFoods) {
			if(f.name == name) {
				if(f.amount > 0) {
					f.amount -= 1;
					PlayerProperties.Inst.IncreaseHealth(f.healAmount);
				}
			}
		}
	}

}
