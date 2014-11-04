using UnityEngine;
using System.Collections;

public class ThirdPersonMove : MonoBehaviour {
	
	Transform tf;
	Transform cam;

	Animator anim;

	Vector3 push = Vector3.zero;
	float pushProp = 0f;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		cam = GetComponentInChildren<ThirdPersonLook> ().GetComponent<Transform> ();
		anim = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 move = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
		float moveSpeed = move.magnitude;
		move = (cam.rotation * move);
		move.y = 0.0f;
		move = (move.normalized * moveSpeed);
		anim.SetBool ("Walking", (move.magnitude > 0.25f));
		//Rotate to match movement
		if (move != Vector3.zero) {
			Quaternion rot = cam.rotation;
			tf.rotation = Quaternion.Slerp (tf.rotation, Quaternion.LookRotation (move), 0.1f);
			cam.rotation = rot;
		}
		//Apply pushes
		if (pushProp > 0.5f) {
			move = Vector3.Lerp (move, (push * 5.0f), Mathf.Min (pushProp, 1f));
			pushProp -= (2.0f * Time.deltaTime);
		}
		//Send the move command
		SendMessage ("SetInputMoveDirection", move);
		SendMessage ("SetInputJump", Input.GetButton ("Jump"));
		if (Input.GetButtonDown ("Jump")) anim.SetTrigger ("Jump");
	}

	public void Shove (Vector3 from) {
		push = (tf.position - from);
		push.y = 0f;
		push.Normalize ();
		pushProp = Mathf.Max (1.5f, pushProp);
	}
}
