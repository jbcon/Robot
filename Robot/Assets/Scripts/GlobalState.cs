using UnityEngine;
using System.Collections;

public class GlobalState : MonoBehaviour {


	public static int gameState;
	/* Global state of game world
	 * 0: no collectibles
	 * 1: one collectible collected
	 * 2: two	"			"
	 * 3: three	"			"		, exit opens
	 */

	// Update is called once per frame
	void start() {
		gameState = 0;
	}

	void Update () {
	
	}
}
