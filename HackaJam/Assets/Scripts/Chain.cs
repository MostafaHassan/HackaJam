﻿using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour {
	public GameObject Player1;
	public GameObject Player2;
	Rigidbody rigBody1;
	Rigidbody rigBody2;
	float maxLength = 100f;
	float force = 20;
	float forcePerc = 1;
	float offsetY = 5.5f;
	float maxPull = 10;
	float maxForce = 5;
	float maxDist = 150;

	// Use this for initialization
	void Start () {
		rigBody1 = Player1.transform.GetComponent<Rigidbody> ();
		rigBody2 = Player2.transform.GetComponent<Rigidbody> ();

	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Player1.transform.position + new Vector3(0, offsetY, 0);
		Vector3 toPlayer2 = (Player2.transform.position - Player1.transform.position).normalized;
		transform.up = toPlayer2;
		float dist = Vector3.Distance (Player1.transform.position, Player2.transform.position);

		transform.localScale = new Vector3 (1,dist*8.0f,1);

		if (dist * 8.0f > maxLength) 
		{
			float forceTo1 = Vector3.Dot(rigBody1.velocity,-toPlayer2);
			float forceTo2 = Vector3.Dot(rigBody2.velocity,toPlayer2);

			if(forceTo1 > forceTo2)
			{
				//Debug.Log("1");
				//move force * %
				//float addForce = Vector3.Dot(rigBody1.velocity,-toPlayer2);
				//addForce = Mathf.Min(maxPull, addForce);
				float addForce = Mathf.Min(dist*8.0f, maxDist )/maxLength;
				rigBody2.AddForce(-toPlayer2*force + -toPlayer2*addForce*forcePerc);
			}
			else if(forceTo1 < forceTo2)
			{
				//Debug.Log("2");
				//float addForce = Vector3.Dot(rigBody2.velocity, toPlayer2);
				//addForce = Mathf.Min(maxPull, addForce);
				float addForce = Mathf.Min(dist*8.0f, maxDist )/maxLength;
				rigBody1.AddForce(toPlayer2*force + toPlayer2*addForce*forcePerc);
			}
			else
			{
				Debug.Log("3");
				//float addForce = Vector3.Dot(rigBody2.velocity, toPlayer2);
				//rigBody1.AddForce(toPlayer2*force);

				//addForce = Vector3.Dot(rigBody1.velocity,-toPlayer2);
				//rigBody2.AddForce(-toPlayer2*force);
			}


		}

		if (Input.GetButton ("Quit")) {
			Application.LoadLevel(0);
		}


	}
}
