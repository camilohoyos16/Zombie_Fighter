using UnityEngine;
using System.Collections;

public class BulletColision : MonoBehaviour  {

	void OnTriggerEnter(Collider other)
	{		
		gameObject.SetActive (false);
	}
}
