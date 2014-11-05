using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public Texture i;
	bool image = false;
	float fade = 0;
	bool fadeUp = true;
	
	
	// Use this for initialization
	void Start () {
		i = Resources.Load ("Slide10") as Texture;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnControllerColliderHit (ControllerColliderHit col)
	{
		if(col.gameObject.name == "Door" && GlobalState.gameState == 3)
		{
			image = true;
			Destroy(col.gameObject);
		}
	}

	void OnGUI()
	{
		if (image)
		{
			GameObject animaticSound = GameObject.FindGameObjectWithTag("AnimaticSound");
			animaticSound.audio.PlayOneShot(animaticSound.audio.clip);
			
			//freeze the game
			Time.timeScale = 0;
			//fade the image
			if (fade<1 && fadeUp)
				fade += 0.005f;
			if (fade >= 1 && fadeUp)
			{
				if (Input.GetMouseButtonDown(0))
				{
					fadeUp = false;
				}
				
			}
			//fade out the image after clicking
			else if (!fadeUp && fade >=0)
				fade -= 0.010f;
			else if (!fadeUp && fade <=0)
			{

				//END THE GAME
				Application.Quit();

				//The game won't quit in the editor
				//In that case, you'll be in free roam
				Time.timeScale = 1;
				image =false;
				GlobalState.gameState +=1;
				
			}
			
			Color old = GUI.color;
			GUI.color = new Color(old.r, old.g, old.b, fade);
			
			GUI.DrawTexture(new Rect(Screen.width*0.5f - i.width/2, 
			                         Screen.height*0.5f - i.height/2,i.width,i.height), i);
			
			GUI.color = old;
		}
	}
}
