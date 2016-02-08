using UnityEngine;
using UnityEngine.UI;
using System.Collections;
//using DG.Tweening;

/*
 * Assessment3
 * Updated to support states
 * Updated to keep consistent and PROPER singleton behaviour
 * 
 * */

public class PlayerProperties : MonoBehaviour {


	public static PlayerProperties inst;

	public static GameObject Player { get { return inst.gameObject; } }

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

	public float defaultHealth = 300;
	public AudioClip hitSound;

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
			Debug.Log ("PlayerProprtties recieved score ");
			pointsText.text = value.ToString();

		} 
	}

	public DuckUI healthUI;

	public Text pointsText;

	void Awake() {
		if (inst == null) {
			inst = this;
		} else {
			Destroy (this);
		}
	}

	// Use this for initialization
	void Start () 
	{
		_health = defaultHealth;
		_audioSource = GetComponent<AudioSource> ();
		DificultyLevel = PlayerPrefs.GetInt ("difficulty");
		Score = 0;
	}

	void OnLevelWasLoaded() {
		healthUI = GameObject.FindGameObjectWithTag ("UI").GetComponent<DuckUI> ();
		pointsText = GameObject.FindGameObjectWithTag ("pointsText").GetComponent<Text> ();
		_audioSource = GetComponent<AudioSource> ();
		DificultyLevel = PlayerPrefs.GetInt ("difficulty");
		pointsText.text = _score.ToString();
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthUI.maxHealth = (int)Mathf.Floor (defaultHealth);

		healthUI.SetHealth ( (int)Mathf.Floor (_health ) );

		if (_health < 1) 
		{
			Die();
		}

		if (Input.GetKeyDown (KeyCode.H)) 
		{
			_health = defaultHealth;
		}
	}

	void Die()
	{
		GameObject instance  = (GameObject)Instantiate(Resources.Load("PlayerDieEffect"));
		instance.transform.position = this.transform.position;

		gameObject.SetActive (false);
	}
	
	void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.name.StartsWith("Enemy")) {
			TakeDamage (50);
			_audioSource.PlayOneShot(hitSound);
			coll.gameObject.BroadcastMessage("Hit");
		}
	}


	private string DamageString(float amount)
	{
		return ((int)Mathf.Floor (amount)).ToString ();
	}

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

	public void TakeDamage(float amount)
	{
		MakeDamageText (-amount);
		_health -= amount;
	}

	public void IncreaseHealth(float amount)
	{
		MakeDamageText (amount);
		_health += amount;
	}

	void SaveProperties()
	{
		PlayerPrefs.SetFloat ("health"		,_health);
		PlayerPrefs.SetInt   ("difficulty"	,DificultyLevel);

		PlayerPrefs.Save ();
	}

	public void SceneSwitch()
	{
		SaveProperties ();
	}

	void OnApplicationQuit() 
	{
		SaveProperties ();
	}
}
