using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	public Texture image1, image2, image3, image4, image5, image6, image7, image8, image9, i;

	int imageNum = 1;
	bool image = false;
	float fade = 0;
	bool fadeUp = true;

	// Use this for initialization
	void Start () {
		image1 = Resources.Load ("Slide1") as Texture;
		image2 = Resources.Load ("Slide2") as Texture;
		image3 = Resources.Load ("Slide3") as Texture;
		image4 = Resources.Load ("Slide4") as Texture;
		image5 = Resources.Load ("Slide5") as Texture;
		image6 = Resources.Load ("Slide6") as Texture;
		image7 = Resources.Load ("Slide1") as Texture;
		image8 = Resources.Load ("Slide2") as Texture;
		image9 = Resources.Load ("Slide3") as Texture;

	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnControllerColliderHit (ControllerColliderHit col)
	{
		if(col.gameObject.name == "Collectable")
		{
			image = true;
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
			if (imageNum == 4)
				i=image4;
			if (imageNum == 5)
				i=image5;
			if (imageNum == 6)
				i=image6;
			if (imageNum == 7)
				i=image7;
			if (imageNum == 8)
				i=image8;
			if (imageNum == 9)
				i=image9;


			//freeze the game
			Time.timeScale = 0;
			//fade the image
			if (fade<1 && fadeUp)
				fade += 0.015f;
			if (fade >= 1 && fadeUp)
			{
				if (Input.GetMouseButtonDown(0))
				{
					fadeUp = false;
				}

			}
			//fade out the image after clicking
			else if (!fadeUp && fade >=0)
				fade -= 0.030f;
			else if (!fadeUp && fade <=0)
			{
				fadeUp = true;
				imageNum+=1;
				if(imageNum == 4 || imageNum == 7 || imageNum == 10)
				{
					Time.timeScale = 1;
					image =false;
					GlobalState.gameState +=1;
				}

			}

			Color old = GUI.color;
			GUI.color = new Color(old.r, old.g, old.b, fade);

			GUI.DrawTexture(new Rect(Screen.width*0.5f - i.width/2, 
			                         Screen.height*0.5f - i.height/2,i.width,i.height), i);

			GUI.color = old;
		}
	}
}
