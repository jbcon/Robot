using UnityEngine;
using System.Collections;

public class PlayAnimaticMusic : MonoBehaviour {

	public AudioClip clip1;
	public AudioClip clip2;
	public AudioClip clip3;
	public AudioClip clip4;


	void Update(){
		if (GlobalState.gameState == 0){
			audio.clip = clip1;
		}
		else if (GlobalState.gameState == 1){
			audio.clip = clip2;
		}
		else if (GlobalState.gameState == 2){
			audio.clip = clip3;
		}
		else{
			audio.clip = clip4;
		}
	}
}
