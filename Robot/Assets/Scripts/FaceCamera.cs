using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {

	Transform tf;
	public Texture i1, i2, i3, i;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform> ();

		i1 = Resources.Load ("pickup1") as Texture;
		i2 = Resources.Load ("pickup1") as Texture;
		i3 = Resources.Load ("pickup1") as Texture;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 point = tf.position - Camera.main.transform.position;
		point.y = 0;

		tf.rotation = Quaternion.LookRotation(point);

		//the rest of this script goes for any 2d object
		//but this part is only for the collectables
		if (gameObject.name == "Collectable")
		{
			if (GlobalState.gameState == 0)
				i = i1;
			else if (GlobalState.gameState == 1)
				i = i2;
			else
				i = i3;

			renderer.material.mainTexture = i;
		}
	}
}
