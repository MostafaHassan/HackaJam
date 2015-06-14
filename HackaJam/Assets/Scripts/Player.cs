using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int PlayerNumber;
	private string AxisX;
	private string AxisY;
	private string JumpButton;
	private string DashButton;

	Transform myChild;
	Animator childAnimator;

	Rigidbody rigBody;

	float moveForce = 3000f;
	float maxMoveForce = 10f;

	float jumpCDMax = 4.0f;
	private float jumpCDLeft = 0f;
	float jumpForce = 700;

	Transform myFeetCol;
	GroundCollide feetColScript;

	float dashCDMax = 5.0f;
	private float dashCDLeft = 0f;
	float dashForce = 700f;

	public Texture backBar;
	public Texture frontBar;
	public Texture playerTex;

	AudioSource audioSour;

	public GameObject goalObject;
	private float winRadius = 50.0f;

	bool haveWon = false;
	public Texture winTexture;

	// Use this for initialization
	void Start () {
		if (PlayerNumber == 1) 
		{
			AxisX = "JoyHor1";
			AxisY = "JoyVer1";
			JumpButton = "JoyJump1";
			DashButton = "JoyDash1";
		} 
		else if (PlayerNumber == 2) 
		{
			AxisX = "JoyHor2";
			AxisY = "JoyVer2";
			JumpButton = "JoyJump2";
			DashButton = "JoyDash2";
		}
		rigBody = transform.GetComponent<Rigidbody> ();

		myChild = transform.FindChild ("Player");
		myFeetCol = transform.FindChild ("FeetCol");

		childAnimator = myChild.transform.GetComponent<Animator> ();
		feetColScript = myFeetCol.transform.GetComponent<GroundCollide> ();
		audioSour = transform.GetComponent<AudioSource> ();

	}



	// Update is called once per frame
	void Update () 
	{

		float x = Input.GetAxis (AxisX);
		float y = Input.GetAxis (AxisY);
		Vector3 controlDir = new Vector3 (x, 0, -y);
		if (controlDir != Vector3.zero) {
			transform.rotation = Quaternion.LookRotation (controlDir);
			//transform.position = transform.position + transform.forward*Time.deltaTime* moveSpeed;
			if (rigBody.velocity.magnitude < maxMoveForce) {
				rigBody.AddForce (transform.forward * Time.deltaTime * moveForce);
				//childAnimator.CrossFade("Walk", 0.25f);

			}
			if(!childAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
			{
				childAnimator.Play ("Walk");
				if(feetColScript.IsGrounded())
				{
					if(!audioSour.isPlaying)
					{
						audioSour.Play();
					}
				}
			}
			//transform.Translate(transform.forward* moveSpeed);
		} 
		else 
		{
			if(!childAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
			{
				childAnimator.Play("Idle");
			}

		}

		//jumpCDLeft -= Time.deltaTime;
		//jumpCDLeft = Mathf.Max (jumpCDLeft, 0);

		if (feetColScript.IsGrounded()) 
		{
			/*if (jumpCDLeft == 0f)
			{*/
			if (Input.GetButton (JumpButton)) 
			{
				if(feetColScript.Jump())
				{
					childAnimator.Play("Jump");
					
					rigBody.AddForce(transform.up* jumpForce);
				}
				
				//jumpCDLeft += jumpCDMax;
				
				
			}

			float toGoalDist = Vector3.Distance( transform.position,goalObject.transform.position ) ;
			if (toGoalDist < winRadius ) 
			{
				Debug.Log("YOU HAVE WON!");
				haveWon = true;
			}
			//}
		}




		dashCDLeft -= Time.deltaTime;
		dashCDLeft = Mathf.Max (dashCDLeft, 0);

		if (dashCDLeft == 0f) 
		{
			if (Input.GetButton (DashButton)) 
			{

				rigBody.AddForce(transform.forward* dashForce);
				dashCDLeft += dashCDMax;
			}
		}


		if (Input.GetButton (JumpButton) && haveWon) 
		{
			Application.LoadLevel(0);
		}
			



	}

	void OnGUI()
	{
		if (PlayerNumber == 1) 
		{
			GUI.DrawTexture(new Rect(Screen.width/100, Screen.height - 2*Screen.height/10, 50, 50), playerTex);
			GUI.DrawTexture (new Rect(Screen.width/100, Screen.height - Screen.height/10, 200, Screen.height/20), backBar);
			GUI.DrawTexture (new Rect(Screen.width/100, Screen.height - Screen.height/10, 200*(dashCDMax-dashCDLeft)/dashCDMax, Screen.height/20), frontBar);
		}
		else if (PlayerNumber == 2)
		{
			GUI.DrawTexture(new Rect(Screen.width - Screen.width/100 - 60, Screen.height - 2*Screen.height/10, 50, 50), playerTex);
			GUI.DrawTexture (new Rect(Screen.width - Screen.width/100 - 200, Screen.height - Screen.height/10, 200, Screen.height/20), backBar);
			GUI.DrawTexture (new Rect(Screen.width - Screen.width/100 - 200*(dashCDMax-dashCDLeft)/dashCDMax, Screen.height - Screen.height/10, 200* (dashCDMax-dashCDLeft)/dashCDMax, Screen.height/20), frontBar);
			                 
		}
		if (haveWon) {
			GUI.DrawTexture(new Rect(Screen.width/2 - 750/2, Screen.height/2 - Screen.height/8, 750, 250), winTexture);
		}
	}


}
