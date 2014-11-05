using UnityEngine;
using System.Collections;

public class PlayerAttackEnemy : MonoBehaviour {

	Transform tf;
	ArrayList enemies;

	Animator anim;

	float cooldown = 0f;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
		anim = tf.parent.GetComponentInChildren<Animator> ();
		enemies = new ArrayList ();
	}
	
	// Update is called once per frame
	void Update () {
		if (cooldown < 0f) {
			if (Input.GetKeyDown (KeyCode.LeftShift)) {
				if (enemies.Count > 0) cooldown += 1.5f;
				anim.SetTrigger ("Hit");
				foreach (EnemyMoveAtPlayer obj in enemies) {
					obj.Hurt (tf.position, (tf.forward + new Vector3(0, 0.5f, 0)));
				}
			}
		} else {
			cooldown -= Time.deltaTime;
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			EnemyMoveAtPlayer enemy = other.GetComponentInParent<EnemyMoveAtPlayer> ();
			if ((enemy != null) && !enemies.Contains(enemy)) {
				enemies.Add (enemy);
			}
		}
	}
		
	void OnTriggerExit (Collider other) {
		if (other.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			enemies.Remove (other.GetComponentInParent<EnemyMoveAtPlayer> ());
		}
	}
}
