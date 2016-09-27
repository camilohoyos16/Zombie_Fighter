using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

	private bool touchFloor;
	private bool jump;
	private bool touchPlatform;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Platform")
			touchPlatform = true;
	}
}
