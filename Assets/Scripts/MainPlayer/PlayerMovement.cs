using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 movementVector;
	[SerializeField ]
	private float movementSpeed;
	[SerializeField ]
	private float jumpPower;
	float joystick;
	private CapsuleCollider playerColl;
	private Rigidbody rb;

	 void Start()
	 {
		rb = GetComponent <Rigidbody > ();
		playerColl = GetComponent <CapsuleCollider> ();
	 }

	void Update ()
	{
		
		joystick = Input.GetAxis ("LeftJoystickY");
	//	movementVector.x = Input.GetAxis ("LeftJoystickX") * movementSpeed;
		float moveVector =Input.GetAxis ("LeftJoystickX") ;
		movementVector.z = Input.GetAxis ("LeftJoystickX") * movementSpeed;


		Jump ();
		Move (moveVector); 

	
	}

	private void Jump()
	{
		if (!PlayerCollisions .Instance .GetJump) {
			movementVector.y = 0;
			if (Input.GetButton ("A")) {
				if (joystick > 0 && !PlayerCollisions.Instance.GetTouchFloor) {
					playerColl.enabled =false ;
					StartCoroutine (ActiveCollider ());
				} else {
					rb.velocity=new Vector3 (0,jumpPower,0);
					ChechkPlatforms.Instance.CheckLevelPLatforms();
					StartCoroutine (RepeatCheck ());
				}
			}
		}	
	}

	private void Move(float moveVector)
	{
		if (moveVector < 0) {
				transform.eulerAngles = new Vector3 (transform.rotation.x, 180f, transform.rotation.z);
				Vector3 vecotrToMove = new Vector3 (0f, rb.velocity.y, movementVector.z * movementSpeed);
				movementVector = vecotrToMove;
				rb.velocity = movementVector;		
		}
		if (moveVector >0)
		{
				transform.eulerAngles = new Vector3 (transform.rotation.x, 0f, transform.rotation.z);		
				Vector3 vecotrToMove = new Vector3 (0f, rb.velocity.y, movementVector.z * movementSpeed);
				movementVector = vecotrToMove;
				rb.velocity = movementVector;
		}
	}

	IEnumerator ActiveCollider()
	{
		yield return new WaitForSeconds (0.33f);
		playerColl.enabled =true ;
	}

	IEnumerator RepeatCheck()
	{
		yield return new WaitForSeconds (0.33f);
		ChechkPlatforms.Instance.CheckLevelPLatforms();
	}

	 
}
