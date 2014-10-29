using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LateUpdate() {
		transform.LookAt(target);
	}
}
