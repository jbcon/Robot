using UnityEngine;
using System.Collections;

public class EnemyMoveAtPlayer : MonoBehaviour {

	Transform tf;
	Rigidbody rb;
	Animator anim;

	Transform target;

	float stunTime = 5.0f;
	float attackTime = 0.0f;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		rb = GetComponent<Rigidbody> ();
		anim = GetComponentInChildren<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				Vector3 dir = (tf.position - hit.point).normalized;
				Hurt (hit.point, dir);
			}
		}
	*/
	}

	void FixedUpdate () {
		Vector3 offset = (target.position - tf.position);
		if (stunTime <= 0.0f) {
			anim.SetBool ("Hit", false);
			//Get chase distance
			float chaseDist = 0f;
			switch (GlobalState.gameState) {
			case (0):
				chaseDist = 20f;
				break;
			case (1):
				chaseDist = 50f;
				break;
			case (2):
				chaseDist = 150f;
				break;
			case (3):
				chaseDist = 300f;
				break;
			}
			Vector3 newVel = Vector3.zero;
			if (offset.magnitude < chaseDist) {
				//Rotate towards target
				Quaternion newRot = new Quaternion ();
				newRot.SetLookRotation (Vector3.Scale (offset.normalized, new Vector3 (1, 0, 1)), Vector3.up);
				tf.rotation = Quaternion.RotateTowards (tf.rotation, newRot, (360f * Time.deltaTime));
				rb.angularVelocity = Vector3.zero;
				//Set velocity
				newVel = Vector3.Slerp (tf.forward, offset.normalized, 0.2f);
				float nearDist = Mathf.Infinity;
				Vector3 nearest = Vector3.zero;
				foreach (EnemyMoveAtPlayer obj in GameObject.FindObjectsOfType<EnemyMoveAtPlayer> ()) {
					if (obj == this) continue;
					Vector3 nearOffset = (obj.GetComponent<Transform> ().position - tf.position);
					float dist = nearOffset.magnitude;
					if (dist < nearDist) {
						nearDist = dist;
						nearest = nearOffset;
					}
				}
				if (nearDist < 5.0f) {
					newVel -= (0.75f * nearest.normalized / nearest.magnitude);
					newVel.Normalize ();
				}
				//Attack if close to the player
				if (offset.magnitude < 3.0f) {
					newVel = Vector3.zero;
					if (attackTime < 0.0f) {
						target.SendMessage("Shove", tf.position);
						attackTime = 1.0f;
						anim.SetTrigger ("Attack");
					}
				}
				newVel *= 7.5f;
				newVel.y = rb.velocity.y;
			}
			rb.velocity = Vector3.MoveTowards (rb.velocity, newVel, (25f * Time.deltaTime));
		} else {
			anim.SetBool ("Hit", true);
			stunTime -= Time.fixedDeltaTime;
		}
		attackTime -= Time.fixedDeltaTime;
	}

	public void Hurt (Vector3 pos, Vector3 dir) {
		if(GlobalState.gameState==0)
			stunTime = Mathf.Max (stunTime, 2.5f);
		if(GlobalState.gameState==1)
			stunTime = Mathf.Max (stunTime, 3.5f);
		if(GlobalState.gameState==2)
			stunTime = Mathf.Max (stunTime, 5.0f);
		if(GlobalState.gameState==3)
			stunTime = Mathf.Max (stunTime, 7.0f);
		dir = Vector3.Scale (dir, new Vector3 (1, 0.5f, 1)).normalized;
		rb.AddForceAtPosition ((800.0f * dir), pos);
	}
}
