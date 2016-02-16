using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
//using DG.Tweening;

/*
 * Assessment3
 * Updated to support states
 * Updated to keep consistent and PROPER singleton behaviour
 * 
 * */

public class PlayerProperties : MonoBehaviour {


	public static PlayerProperties inst;

	//public static GameObject Player { get { return inst.gameObject; } }

	public static Vector3 Position  
	{
		get 
		{
			if(inst == null)
			{
				return new Vector3(0,0,0);
			}
			else 
			{
				return inst.gameObject.transform.position; 
			}
		} 
	}

	public Color explodeColor;

	public string curState;

	public int DificultyLevel;

	public float defaultHealth = 100;
	float shealth;//startHealth
	public float healthMultiplier = 1.0f;
	public AudioClip hitSound;

	public float protectionAmount;

	private AudioSource _audioSource;
	private float _health = 0;

	private int _score;

	public int Score 
	{ 
		get
		{
			return _score;
		} 
		set
		{
			_score = value;
			//Debug.Log ("PlayerProprtties recieved score ");
			pointsText.text = value.ToString();

		} 
	}

	public DuckUI healthUI;

	public Text pointsText;

	void Awake() {
		if (inst == null) {
			inst = this;
		}
		shealth = defaultHealth;
	}

	// Use this for initialization
	void Start () 
	{
		_health = defaultHealth;
		_audioSource = GetComponent<AudioSource> ();
		DificultyLevel = PlayerPrefs.GetInt ("difficulty");
		//Score = 0;
	}

	void OnLevelWasLoaded() {
		//reassign UI elements as they arent singleton for some reason.
		healthUI = GameObject.FindGameObjectWithTag ("UI").GetComponent<DuckUI> ();
		pointsText = GameObject.FindGameObjectWithTag ("pointsText").GetComponent<Text> ();
		_audioSource = GetComponent<AudioSource> ();
		DificultyLevel = PlayerPrefs.GetInt ("difficulty");
		pointsText.text = _score.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//keep ui up to date
		healthUI.maxHealth = (int)Mathf.Floor (defaultHealth);

		healthUI.SetHealth ( (int)Mathf.Floor (_health ) );

		//if we are dead then we die
		if (_health < 1) 
		{
			Die();
		}
		//keep health updated
		defaultHealth = shealth * healthMultiplier;
		//≥≤Debug.Log (Time.time + "    " + this.gameObject + _score);
	}

	/// <summary>
	/// kills player
	/// </summary>
	void Die()
	{
		GameObject instance  = (GameObject)Instantiate(Resources.Load("PlayerDieEffect"));
		instance.transform.position = this.transform.position;

		gameObject.SetActive (false);
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		//take damage when we hit an enemy
		//usnig name.startswith is a VERY VERY VERY unreliable way to do this.
		if (coll.gameObject.name.StartsWith("Enemy")) {
			TakeDamage (50);
			_audioSource.PlayOneShot(hitSound);
			//dont know where this broadcast statement goes. 
			//It is undocumented
			coll.gameObject.BroadcastMessage("Hit");
		}
	}

	//not used
	private string DamageString(float amount)
	{
		return ((int)Mathf.Floor (amount)).ToString ();
	}
	//not used in assessment 3
	private void MakeDamageText(float amount)
	{
		if (amount != 0)
		{
			Color color = Color.red;
			string text = "";

			if (amount > 0)
			{
				text = "+";
				color = Color.green;
			}

			text += ((int)Mathf.Floor (amount)).ToString ();

			//FloatingTextManager.MakeFloatingText (transform, text, color);
		}
	}
	/// <summary>
	/// Takes some damage.
	/// </summary>
	/// <param name="amount">Amount to take.</param>
	public void TakeDamage(float amount)
	{
		//MakeDamageText (-amount);
		_health -= amount;
		if (_health <= 0) {
			Dead ();
		}
	}
	//increases player health
	public void IncreaseHealth(float amount)
	{
		//MakeDamageText (amount);
		_health += amount;
	}
	//assessment2 thing
	void SaveProperties()
	{
		PlayerPrefs.SetFloat ("health"		,_health);
		PlayerPrefs.SetInt   ("difficulty"	,DificultyLevel);

		PlayerPrefs.Save ();
	}
	//assessment2 thing
	public void SceneSwitch()
	{
		SaveProperties ();
	}
		//assessment2 thing
	void OnApplicationQuit() 
	{
		SaveProperties ();
	}

	/// <summary>
	/// player dead.
	/// </summary>
	void Dead() {
		SceneManager.LoadScene ("Cell");
		Destroy (GameObject.FindGameObjectWithTag ("Statics"));
	}
}
