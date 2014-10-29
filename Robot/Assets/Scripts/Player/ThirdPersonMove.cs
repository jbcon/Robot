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
		float moveSpeed = move.magnitude;
		move = (cam.rotation * move);
		move.y = 0.0f;
		move = (move.normalized * moveSpeed);
		SendMessage ("SetInputMoveDirection", move);
		SendMessage ("SetInputJump", Input.GetButton ("Jump"));
		//Rotate to match movement
		if (move != Vector3.zero) {
			Quaternion rot = cam.rotation;
			tf.rotation = Quaternion.Slerp (tf.rotation, Quaternion.LookRotation (move), 0.1f);
			cam.rotation = rot;
		}
	}
}
