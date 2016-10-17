using UnityEngine;
using System.Collections;

public class PlayerCollisions : MonoBehaviour {

	public delegate void Hit();
	public static event Hit playerHit;

	private  bool touchFloor;
	private bool jump;
	//[HideInInspector ]
	private bool touchPlatform=false;

	private CapsuleCollider playerColl;


	public static PlayerCollisions instance;
	public static PlayerCollisions Instance
	{
		get{
			return instance;
		}
	}

	void Awake()
	{
		if(!instance)
			instance = this;
		touchPlatform = false;
		playerColl = GetComponent <CapsuleCollider> ();
	}

	void Update()
	{
		if (!touchFloor && !touchPlatform)
			jump = true;
		else
			jump = false;
	}

	void CallEvent()
	{
		if (playerHit != null)
			playerHit ();
	}

	void OnCollisionEnter(Collision other)
	{		
		if (other.gameObject.tag == "Platform")
			touchPlatform = true;
		if (other.gameObject.tag == "Floor")
			touchFloor = true;
		if (other.gameObject.tag == "Enemy") 
		{
			if (this.gameObject.layer == 13) {
				CallEvent ();
				this.gameObject.layer = 19;
				StartCoroutine (RestoreCollision ());
			}
		}
	}

	IEnumerator RestoreCollision()
	{
		yield return new WaitForSeconds (2f);
		this.gameObject.layer = 13;
	}

	void OnCollisionExit(Collision other)
	{
		if (other.gameObject.tag == "Platform")
			touchPlatform = false;
		if (other.gameObject.tag == "Floor")
			touchFloor = false;
	}

	public bool GetTouchFloor
	{
		get{
			return touchFloor;
		}
	}

	public bool GetTouchPlatform
	{
		get{
			return touchPlatform;
		}
	}

	public bool GetJump
	{
		get{
			return jump;
		}
	}
}
