using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	Camera cam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 myFocus = player1.transform.position + (player2.transform.position - player1.transform.position)/2.0f;
		transform.LookAt (myFocus);
	}
}
