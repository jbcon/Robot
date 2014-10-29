using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnControllerColliderHit (ControllerColliderHit col)
	{
		Debug.Log ("hit");
		if(col.gameObject.name == "Collectable")
		{
			Destroy(col.gameObject);
		}
	}
}
