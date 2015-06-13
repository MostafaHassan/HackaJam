using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	float maxDistance = 10f;
	float speed = 0.1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myFocus = player1.transform.position + (player2.transform.position - player1.transform.position)/2.0f;
		transform.LookAt (myFocus);

		float playerZ = Mathf.Min (player1.transform.position.z, player2.transform.position.z);

		float cameraZ = transform.position.z;



		if (playerZ - cameraZ > maxDistance) 
		{
			transform.position = transform.position + new Vector3(myFocus.x, 0, myFocus.z).normalized*(playerZ - cameraZ)*Time.deltaTime*speed;
		}

		
	}
}
