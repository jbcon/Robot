using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {


	public float jumpForce = 25f;

	Transform tf;
	bool jumped = false;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){ //0 is left, 1 is right
			tf.Translate(0.1f, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.A)){ //0 is left, 1 is right
			tf.Rotate(0f, -1.5f, 0f);
		}
		if(Input.GetKey(KeyCode.S)){ //0 is left, 1 is right
			tf.Translate(-0.1f, 0f, 0f);
		}
		if(Input.GetKey(KeyCode.D)){ //0 is left, 1 is right
			tf.Rotate(0f, 1.5f, 0f);
		}
<<<<<<< HEAD
		if(Input.GetKey (KeyCode.Space)){
			jumped = true;
		}
	}

	void FixedUpdate(){
		if(jumped){
			rigidbody.AddForce(Vector3.up * jumpForce);
			jumped = false;
		}
=======
		//if(Input.GetKey(KeyCode.Space)){ //0 is left, 1 is right

		//}
>>>>>>> 76183e3efb94760f1e4b93d17e95719926201a5e
	}
}
