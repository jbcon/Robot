using UnityEngine;
using System.Collections;

public class PlayAnimaticMusic : MonoBehaviour {

	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;


	void playStateClip(){
		if (GlobalState.gameState == 0){
			audio.clip = clip1;
		}
		if (GlobalState.gameState == 1){
			audio.clip = clip2;
		}
		if (GlobalState.gameState == 2){
			audio.clip = clip3;
		}
	}
}
