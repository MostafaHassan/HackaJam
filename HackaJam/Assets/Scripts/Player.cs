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
	float dashForce = 500f;




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

	



	}

	void OnGUI()
	{

	}


}
