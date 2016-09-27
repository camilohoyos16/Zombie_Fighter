using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	private Vector3 movementVector;
	private CharacterController characterController;
	private float movementSpeed = 8;
	private float jumpPower = 15;
	private float gravity = 40;

	 void Start()
	 {
	 characterController = GetComponent<CharacterController>();	  
	 }

	void Update ()
	{
	//	movementVector.x = Input.GetAxis ("LeftJoystickX") * movementSpeed;
		float moveVector =Input.GetAxis ("LeftJoystickX") ;
		movementVector.z = Input.GetAxis ("LeftJoystickX") * movementSpeed;

		if (characterController.isGrounded) {
			movementVector.y = 0;
			if (Input.GetButton ("A")) {
				movementVector.y = jumpPower;
			}
		}

		if (moveVector < 0)
			transform.eulerAngles = new Vector3 (transform.rotation.x, 180f, transform.rotation.z);
		if (moveVector > 0)
			transform.eulerAngles = new Vector3 (transform.rotation.x, 0f, transform.rotation.z);
		
		
		movementVector.y -= gravity * Time.deltaTime;
		characterController.Move (movementVector * Time.deltaTime);
	}
		 
	 
}
