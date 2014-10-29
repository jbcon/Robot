using UnityEngine;
using System.Collections;

public class ThirdPersonMove : MonoBehaviour {
	
	Transform tf;
	Transform cam;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		cam = GetComponentInChildren<ThirdPersonLook> ().GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		move = (cam.rotation * move);
		SendMessage ("SetInputMoveDirection", move);
		SendMessage ("SetInputJump", Input.GetButton ("Jump"));
		//Rotate to match movement
		if (move != Vector3.zero) {
			Quaternion rot = cam.rotation;
			tf.rotation = Quaternion.RotateTowards (tf.rotation, Quaternion.LookRotation (move), 5.0f);
			cam.rotation = rot;
		}
	}
}
