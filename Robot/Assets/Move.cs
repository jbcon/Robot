using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {


	Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){ //0 is left, 1 is right
			tf.Translate(0.1f, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.A)){ //0 is left, 1 is right
			tf.Rotate(0f, -1f, 0f);
		}
		if(Input.GetKey(KeyCode.S)){ //0 is left, 1 is right
			tf.Translate(-0.1f, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.D)){ //0 is left, 1 is right
			tf.Rotate(0f, 1f, 0f);
		}
	}
}
