using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	[SerializeField ]
	private Transform player;
	private bool canShoot;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform> ();
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
		float shoot = Input.GetAxis ("TriggerRT");

		if (shoot == 1f && canShoot) {
			BulletMove.Spawn (transform.position, transform.rotation);
			canShoot = false;
		}
		else
			if (shoot ==0)
				canShoot = true;
	}
}
