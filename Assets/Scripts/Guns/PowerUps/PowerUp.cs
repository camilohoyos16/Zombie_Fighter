using UnityEngine;
using System.Collections;

public abstract class PowerUp : MonoBehaviour, IWeapon {

	public GameObject player;
	private void Awake()
	{
		player = GameObject .Find ("Player");
	}

	public int Ammo {
		get;
		set;
	}

	public bool HasAmmo
	{
		get 
		{
			return Ammo >0;
		}
	}

	public void Shoot()
	{
		if (HasAmmo) 
		{
			ShootPowerUp ();
			Ammo--;
		}
	}
	protected abstract void ShootPowerUp ();
}
