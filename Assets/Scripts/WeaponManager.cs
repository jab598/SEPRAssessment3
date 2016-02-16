using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Weapon manager.
/// 
/// Used to control which weapon object is active. 
/// 
/// It will also save and retrieve the selected weapon on scene switch.
/// 
/// ASSESSMENT3
/// Re-worked so it actually works properly, as you would expect.
/// All weapons are present at the start
/// 
/// </summary>
public class WeaponManager : MonoBehaviour {
		
	public GameObject[] weapons;

	/// <summary>
	/// The name of the _selected weapon for savinge between scenes.
	/// </summary>
	string _selectedWeaponName;

	//Dependent on name.
	int _selectedWeaponIndex = 0;



	void Awake()
	{
		//See if we saved our selected weapon from the last scene.
		if (PlayerPrefs.HasKey ("SelectedWeapon"))
		{
			_selectedWeaponName = PlayerPrefs.GetString("SelectedWeapon");
		}

		//Now the name is set we need to enable the weapon with that name.
		RefreshActiveWeapons ();
	}


	void RefreshActiveWeapons()
	{
		for (int i = 0; i < weapons.Length; i++)
		{
			//update all of the weapon actives, so [true, false, false, false] if weap1
			weapons[i].SetActive(i == _selectedWeaponIndex);
		}
	}


	void Update () 
	{
		if(Input.GetAxisRaw("Mouse ScrollWheel") < 0  ||  Input.GetButtonUp("NextWeapon"))
		{
			SelectWeaponIndex (_selectedWeaponIndex + 1);
		}
		if(Input.GetAxisRaw("Mouse ScrollWheel") > 0  ||  Input.GetButtonUp("PrevWeapon"))
		{
			SelectWeaponIndex (_selectedWeaponIndex - 1);
		}   
	}


	void SelectWeaponIndex(int i)
	{
		_selectedWeaponIndex = Mathf.Clamp (i, 0, weapons.Length-1);
		_selectedWeaponName  =  weapons[_selectedWeaponIndex].name;
		Debug.Log ("Selecting weapon " + _selectedWeaponIndex);
		RefreshActiveWeapons ();

		//Hack to integrate UI Code
		transform.parent.GetComponent<UIWeapons>().weaponUIText.text = _selectedWeaponName;
	}


	public void SceneSwitch()
	{
		PlayerPrefs.SetString("SelectedWeapon", _selectedWeaponName);
	}
}
