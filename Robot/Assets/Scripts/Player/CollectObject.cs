using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	public Texture image1;
	int image = 0;
	float fade = 0;
	bool fadeUp = true;

	// Use this for initialization
	void Start () {
		image1 = Resources.Load ("Placeholder") as Texture;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnControllerColliderHit (ControllerColliderHit col)
	{
		if(col.gameObject.name == "Collectable")
		{
			image = 1;
			Destroy(col.gameObject);
		}
	}
	void OnGUI()
	{
		if (image != 0)
		{
			Time.timeScale = 0;
			if (fade<1 && fadeUp)
				fade += 0.002f;
			if (fade >= 1 && fadeUp)
			{
				if (Input.GetMouseButtonDown(0))
				{
					fadeUp = false;
				}

			}
			else if (!fadeUp && fade >=0)
				fade -= 0.006f;
			else if (!fadeUp && fade <=0)
			{
				fadeUp = true;
				Time.timeScale = 1;
				image =0;
			}

			Color old = GUI.color;
			GUI.color = new Color(old.r, old.g, old.b, fade);
			if (image == 1)
				GUI.DrawTexture(new Rect(50,50,400,400), image1);
			GUI.color = old;
		}
	}
}
