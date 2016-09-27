using UnityEngine;
using System.Collections;

public class Aim : MonoBehaviour {


	private Vector3 movementVector;
	private float aimmingSpeed=8f;

	//public GameObject mira;
	// Use this for initialization
	void Start () {
		movementVector.x = 4.78f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		movementVector.y = Input.GetAxis ("RightJoystickY") * aimmingSpeed;
		movementVector.z = Input.GetAxis ("RightJoystickX") * aimmingSpeed;
		Move ();

	}

	private void Move()
	{
		Vector3 move;
		move.x = transform.position.x + movementVector.x;
		move.y = transform.position.x + movementVector.y;
		move.z = movementVector.z;
		transform.position = move * Time.deltaTime;
	}
}
