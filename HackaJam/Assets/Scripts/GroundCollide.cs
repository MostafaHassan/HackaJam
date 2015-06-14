using UnityEngine;
using System.Collections;

public class GroundCollide : MonoBehaviour {

	bool isGrounded = false;
	float cooldown = 0.0f;

	bool dead = false;
	float deathCooldown = 3.0f;

	public Texture deathScreen;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		cooldown = Mathf.Max (0, cooldown);
		if (dead) 
		{
			deathCooldown -= Time.deltaTime;
			if(deathCooldown <= 0)
			{
				Debug.Log("YOU DIED");
				Application.LoadLevel(1);

			}
		}
	
	}

	void OnTriggerEnter(Collider mCol)
	{
		Debug.Log ("Is running");

		if (mCol.transform.tag != "Player") {
			isGrounded = true;
			cooldown = 0.25f;
		} 
		if (mCol.transform.tag == "Lava") {
			Debug.Log("Dying");
			dead = true;
		}


	}

	public bool Jump()
	{
		if (cooldown == 0) 
		{
			isGrounded = false;
			return true;
		}
		return false;
	}

	public bool IsGrounded()
	{
		return isGrounded;
	}

	void OnGUI()
	{
		if (dead) 
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - 750/2, Screen.height/2 - Screen.height/8, 750, 250), deathScreen);
		}
	}
}
