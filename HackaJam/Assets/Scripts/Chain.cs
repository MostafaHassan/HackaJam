using UnityEngine;
using System.Collections;

public class Chain : MonoBehaviour {
	public GameObject Player1;
	public GameObject Player2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 myFocus = Player1.transform.position + (Player2.transform.position - Player1.transform.position)/2.0f;
		transform.position = myFocus;

		Vector3 chainPos = transform.position;
		Vector3 vec = Player1.transform.position - Player2.transform.position;
		vec = Vector3.Normalize (vec);

		Vector3 rotVec = Vector3.Cross (vec, Vector3.up);


		//rotVec = Vector3.Normalize (rotVec);
		transform.rotation = Quaternion.LookRotation( Vector3.RotateTowards(transform.forward, rotVec, 5f, 0));

		//Vector2 xy1 = new Vector2 (Player1.transform.position.x, Player1.transform.position.y );
		//Vector2 xy2 = new Vector2 (Player2.transform.position.x, Player2.transform.position.y );



	}
}
