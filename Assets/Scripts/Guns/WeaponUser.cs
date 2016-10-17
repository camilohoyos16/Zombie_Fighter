using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MainWeapon ))]
public class WeaponUser : MonoBehaviour {

	private MainWeapon weapon;
	private bool canShoot;

	private void Awake()
	{
		weapon = GetComponent <MainWeapon > ();
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float shoot = Input.GetAxis ("TriggerRT");

		if (shoot == 1f && canShoot) {
			weapon.Shoot ();
			canShoot = false;
		}
		else
			if (shoot ==0)
				canShoot = true;
		if(Input .GetKeyDown(KeyCode .Space))
		{
			weapon.AddDoubleCanon ();	
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "DoubleCanon") {
			weapon.AddDoubleCanon ();
			Destroy (other .gameObject);
		}
		if (other.transform.tag == "TripleCanon") {
			weapon.AddTripleCanon ();
			Destroy (other .gameObject);
		}			
	}
}

