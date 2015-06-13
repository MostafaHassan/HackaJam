using UnityEngine;
using System.Collections;

public class PlayerTest : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public GameObject p1JointOuter;
	public GameObject p1Joint;

	public GameObject p2JointOuter;
	public GameObject p2Joint;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p1Pos = new Vector3 (player1.transform.position.x,
		                            player1.transform.position.y,
		                            player1.transform.position.z);

		//RotateTowards ( p1Joint.transform, player1.transform );
		//RotateTowards ( p1JointOuter.transform, player1.transform );

		//RotateTowards ( p2Joint.transform, player2.transform );
		//RotateTowards ( p2JointOuter.transform, player2.transform );
	}

	void RotateTowards( Transform a, Transform b)
	{
		float originalRotX = a.rotation.eulerAngles.x;
		Quaternion targetRotation = Quaternion.LookRotation (b.position - a.position);
		float str = Mathf.Min (0.5f * Time.deltaTime, 1);
		a.rotation = Quaternion.Lerp (a.rotation, targetRotation, str);
		//p1Joint.transform.eulerAngles = new Vector3 ();

		//a.eulerAngles = new Vector3( originalRotX, a.rotation.y, a.rotation.z);
	}

}
