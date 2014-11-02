using UnityEngine;
using System.Collections;

public class PlayerAttackEnemy : MonoBehaviour {

	Transform tf;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Ray ray = new Ray ((tf.position + tf.forward), tf.forward);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 3f)) {
				if (hit.collider.gameObject.tag == "Enemy") {
					hit.collider.GetComponentInParent<EnemyMoveAtPlayer> ().Hurt (tf.position, tf.forward);
				}
			}
		}
	}
}
