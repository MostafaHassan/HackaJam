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

	float moveForce = 1000f;
	float maxMoveForce = 5f;

	float jumpCDMax = 4.0f;
	private float jumpCDLeft = 0f;
	float jumpForce = 400f;

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
		childAnimator = myChild.transform.GetComponent<Animator> ();
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
				childAnimator.Play ("Walk");
			}

			//transform.Translate(transform.forward* moveSpeed);
		} 
		else 
		{
			childAnimator.CrossFade("Idle", 0.25f);
		}

		jumpCDLeft -= Time.deltaTime;
		jumpCDLeft = Mathf.Max (jumpCDLeft, 0);

		if (jumpCDLeft == 0f) 
		{
			if (Input.GetButton (JumpButton)) 
			{
				childAnimator.Play("Jump");


				rigBody.AddForce(transform.up* jumpForce);
				jumpCDLeft += jumpCDMax;


			}
		}

		dashCDLeft -= Time.deltaTime;
		dashCDLeft = Mathf.Max (dashCDLeft, 0);

		if (dashCDLeft == 0f) 
		{
			if (Input.GetButton (DashButton)) 
			{

				Debug.Log(DashButton);
				rigBody.AddForce(transform.forward* dashForce);
				dashCDLeft += dashCDMax;
			}
		}
	



	}
}
