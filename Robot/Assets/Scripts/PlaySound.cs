using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	AudioSource source;	

	// Use this for initialization
	void Start () {
		source = gameObject.AddComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySoundOnce (AudioClip sound) {
		source.PlayOneShot (sound);
	}
}
