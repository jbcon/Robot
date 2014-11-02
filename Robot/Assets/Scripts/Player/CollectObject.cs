using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	public Texture image1, image2, image3, i;
	int imageNum = 0;
	bool image = false;
	float fade = 0;
	bool fadeUp = true;

	// Use this for initialization
	void Start () {
		image1 = Resources.Load ("Placeholder") as Texture;
		image2 = Resources.Load ("Placeholder") as Texture;
		image3 = Resources.Load ("Placeholder") as Texture;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnControllerColliderHit (ControllerColliderHit col)
	{
		if(col.gameObject.name == "Collectable")
		{
			image = true;
			imageNum+=1;
			Destroy(col.gameObject);
		}
	}
	void OnGUI()
	{
		if (image)
		{
			//chose which image to show
			if (imageNum == 1)
				i=image1;
			if (imageNum == 2)
				i=image2;
			if (imageNum == 3)
				i=image3;

			//freeze the game
			Time.timeScale = 0;
			//fade the image
			if (fade<1 && fadeUp)
				fade += 0.003f;
			if (fade >= 1 && fadeUp)
			{
				if (Input.GetMouseButtonDown(0))
				{
					fadeUp = false;
				}

			}
			//fade out the image after clicking
			else if (!fadeUp && fade >=0)
				fade -= 0.006f;
			else if (!fadeUp && fade <=0)
			{
				fadeUp = true;
				Time.timeScale = 1;
				image =false;
			}

			Color old = GUI.color;
			GUI.color = new Color(old.r, old.g, old.b, fade);

			GUI.DrawTexture(new Rect(Screen.width*0.5f - i.width/2, 
			                         Screen.height*0.5f - i.height/2,i.width,i.height), i);

			GUI.color = old;
		}
	}
}
