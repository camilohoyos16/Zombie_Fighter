using UnityEngine;
using System.Collections;

public class CatchPowerUp : MonoBehaviour {

	private MainWeapon weapon;
	// Use this for initialization
	void Start () {
		weapon = GameObject.Find ("Player").GetComponent <MainWeapon > ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	/*void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Player") 
		{
			if (this.transform.name == "DoubleCanon") 
			{
				weapon.AddDoubleCanon ();
			}
			if (this.transform.name == "TripleCanon") 
			{
				weapon.AddDoubleCanon ();
				weapon.AddTripleCanon ();
			}
			Destroy (this.gameObject);
		}
	}
*/
}
