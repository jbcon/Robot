using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalState.gameState < 3)
			renderer.enabled = false;
		else
			renderer.enabled = true;
		Color color = renderer.material.color;
		float dis = Vector3.Distance (transform.position, GameObject.Find("RobotController").transform.position) / 100 - 0.2f;
		color.a = dis;
		renderer.material.color = color;

	}
}
