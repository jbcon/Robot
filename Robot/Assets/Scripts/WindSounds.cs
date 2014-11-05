using UnityEngine;
using System.Collections;

public class WindSounds : MonoBehaviour {

	AudioSource source;
	float time = 0f;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0f) {
			source.PlayOneShot (source.clip);
			time += Random.Range (1f, 2.5f);
		}
	}
}
