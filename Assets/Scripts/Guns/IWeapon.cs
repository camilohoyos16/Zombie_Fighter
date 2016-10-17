using UnityEngine;
using System.Collections;

public interface  IWeapon {

	bool HasAmmo {
		get;
	}
	void Shoot ();
}
