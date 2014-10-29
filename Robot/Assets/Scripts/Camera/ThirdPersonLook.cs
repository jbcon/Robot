using UnityEngine;
using System.Collections;

public class ThirdPersonLook : MonoBehaviour {

	float sensitivity = 5.0f;
	Transform tf;

	float rotationY;

	float rotYMin = -75;
	float rotYMax = 85;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		rotationY = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 rot = (new Vector2 (Input.GetAxis ("Mouse X"), Input.GetAxis ("Mouse Y")) * sensitivity);
		float rotationX = (tf.localEulerAngles.y + rot.x);
		rotationY = Mathf.Clamp ((rotationY + rot.y), rotYMin, rotYMax);
		tf.localEulerAngles = new Vector3 (-rotationY, rotationX, 0f);
	}
}
