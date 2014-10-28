using UnityEngine;
using System.Collections;

public class EnemyMoveAtPlayer : MonoBehaviour {

	Transform tf;
	Rigidbody rb;

	Transform target;

	float stunTime = 5.0f;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Vector3 dir = (tf.position - hit.point).normalized;
				Hurt (hit.point, dir);
			}
		}
	}

	void FixedUpdate () {
		Vector3 offset = (target.position - tf.position);
		offset.y = 0;
		if (stunTime <= 0.0f) {
			//Rotate towards target
			Quaternion newRot = new Quaternion ();
			newRot.SetLookRotation (offset.normalized, Vector3.up);
			tf.rotation = Quaternion.RotateTowards (tf.rotation, newRot, (360f * Time.deltaTime));
			rb.angularVelocity = Vector3.zero;
			//Set velocity
			Vector3 newVel = (Vector3.Slerp (tf.forward, offset.normalized, 0.2f) * 5.0f);
			if (offset.magnitude < 5.0f) newVel = Vector3.zero;
			newVel.y = rb.velocity.y;
			rb.velocity = Vector3.MoveTowards (rb.velocity, newVel, (10f * Time.deltaTime));
		} else {
			stunTime -= Time.deltaTime;
		}
	}

	void Hurt (Vector3 pos, Vector3 dir) {
		stunTime = Mathf.Max (stunTime, 3.0f);
		dir = Vector3.Scale (dir, new Vector3 (1, 0.5f, 1)).normalized;
		rb.AddForceAtPosition ((800.0f * dir), pos);
	}
}
