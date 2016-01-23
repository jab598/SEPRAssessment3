using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartMenu : MonoBehaviour 
{
	public Slider difficultySlider;
	public Slider volumeSlider;

	public void startGame()
	{
		PlayerPrefs.SetInt ("difficulty", (int)difficultySlider.value);
		AudioListener.volume = volumeSlider.value;
		Application.LoadLevel (1);
	}
}
