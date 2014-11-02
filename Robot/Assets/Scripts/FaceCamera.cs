using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 point = Camera.main.transform.position;
		point.y = 0;
		tf.LookAt (point);
	}
}
