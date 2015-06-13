using UnityEngine;
using System.Collections;

public class Tail : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 vec2 = new Vector2 (player1.transform.position.x, player1.transform.position.y);

	}
}
