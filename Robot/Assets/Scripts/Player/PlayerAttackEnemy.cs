using UnityEngine;
using System.Collections;

public class PlayerAttackEnemy : MonoBehaviour {

	Transform tf;
	ArrayList enemies;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		enemies = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			foreach (EnemyMoveAtPlayer obj in enemies) {
				obj.Hurt (tf.position, tf.forward);
			}
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			EnemyMoveAtPlayer enemy = other.GetComponentInParent<EnemyMoveAtPlayer> ();
			if (!enemies.Contains(enemy)) enemies.Add (enemy);
		}
	}
		
	void OnTriggerExit (Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			enemies.Remove (other.GetComponentInParent<EnemyMoveAtPlayer> ());
		}
	}
}
