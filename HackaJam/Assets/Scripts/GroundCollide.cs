using UnityEngine;
using System.Collections;

public class GroundCollide : MonoBehaviour {

	bool isGrounded = false;
	float cooldown = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		cooldown -= Time.deltaTime;
		cooldown = Mathf.Max (0, cooldown);
	
	}

	void OnTriggerEnter(Collider mCol)
	{

		if (mCol.transform.tag != "Player") 
		{
			Debug.Log("ERROR");
			isGrounded = true;
			cooldown = 0.25f;
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
}
