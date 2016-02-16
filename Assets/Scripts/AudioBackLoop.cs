using UnityEngine;
using System.Collections;

public class AudioBackLoop : MonoBehaviour {

	/// <summary>
	/// The background track.
	/// </summary>
	public AudioClip backgroundTrack;

	//singleton
	public static AudioBackLoop inst;


	AudioSource source;
	// Use this for initialization

	void Start () {
		//singleton
		if (inst == null) {
			inst = this;
		} else {
			Destroy (this.gameObject);
		}
		//builds this audiosource and sets it all up
		if (this.GetComponent<AudioSource> () == null) {
			this.gameObject.AddComponent<AudioSource> ();
			source = this.gameObject.GetComponent<AudioSource> ();
			source.loop = true;
			source.clip = backgroundTrack;
			source.Play ();
		}
		DontDestroyOnLoad (this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
