using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public Texture backGround;

	public Texture gameButSelec;
	public Texture gameButNorm;

	public Texture quitButSelec;
	public Texture quitButNorm;

	public Texture controller;

	int selected = 0;
	float cooldown = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		cooldown = Mathf.Max (0, cooldown);

		if (cooldown == 0) 
		{
			float x = Input.GetAxis ("JoyVerAll");
			if(x < -0.8f)
			{
				//up
				selected--;
				selected = Mathf.Max(selected, 0);
			}
			else if(x > 0.8f)
			{
				//down
				selected++;
				selected = Mathf.Min(selected, 1);
			}
		}

		if (Input.GetButton ("JoyJumpAll")) 
		{
			if(selected == 0)
			{
				Application.LoadLevel(1);
			}
			else if(selected == 1)
			{
				Application.Quit();
			}
		}
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backGround);
		GUI.DrawTexture (new Rect (Screen.width - Screen.width / 3, Screen.height / 3 + 200, Screen.width /3, Screen.height/3), controller);
		if (selected == 0) 
		{
			GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 10, Screen.height / 2, Screen.width / 5, Screen.height / 10), gameButSelec);
			GUI.DrawTexture (new Rect (Screen.width / 2- Screen.width / 10, Screen.height / 2 + Screen.height / 8, Screen.width / 5, Screen.height / 10), quitButNorm);
		} 
		else 
		{
			GUI.DrawTexture (new Rect (Screen.width / 2 - Screen.width / 10, Screen.height / 2, Screen.width / 5, Screen.height / 10), gameButNorm);
			GUI.DrawTexture (new Rect (Screen.width / 2- Screen.width / 10, Screen.height / 2 + Screen.height / 8, Screen.width / 5, Screen.height / 10), quitButSelec);
		}


	}
}
