using UnityEngine;
using System.Collections;

public class ThirdPersonLook : MonoBehaviour {

	float sensitivity = 5.0f;
	Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		//tf.Rotate (tf.right, (Input.GetAxis ("Mouse Y") * sensitivity));
		tf.Rotate (Vector3.up, (Input.GetAxis ("Mouse X") * sensitivity));
	}
}
