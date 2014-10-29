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
			Ray ray = new Ray (tf.position, tf.forward);
			RaycastHit hit;
			if (Physics.SphereCast (ray, 1f, out hit, 2.5f)) {
				if (hit.collider.gameObject.tag == "Enemy") {
					Debug.Log (hit.point);
				}
			}
		}
	}
}
