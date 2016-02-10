using UnityEngine;
using System.Collections;

public class AudioBackLoop : MonoBehaviour {

	public AudioClip backgroundTrack;

	public static AudioBackLoop inst;


	AudioSource source;
	// Use this for initialization
	void Start () {
		if (inst == null) {
			inst = this;
		} else {
			Destroy (this.gameObject);
		}
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
