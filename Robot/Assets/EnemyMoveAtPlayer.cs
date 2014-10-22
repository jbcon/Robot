using UnityEngine;
using System.Collections;

public class EnemyMoveAtPlayer : MonoBehaviour {

	Transform tf;
	Rigidbody rb;

	Transform target;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 offset = (target.position - tf.position);
		offset.y = 0;
		//Rotate towards target
		tf.forward = Vector3.RotateTowards (tf.forward, offset.normalized, (1f * Time.deltaTime), Time.deltaTime);
		//Set velocity
		Vector3 newVel = (Vector3.Slerp (tf.forward, offset.normalized, 0.2f) * 5.0f);
		newVel.y = rb.velocity.y;
		rb.velocity = Vector3.MoveTowards (rb.velocity, newVel, (10.0f * Time.deltaTime));
	}
}
