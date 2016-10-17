using UnityEngine;
using System.Collections.Generic;

public class MainWeapon : MonoBehaviour, IWeapon{

	public bool HasAmmo
	{ 
		get{
			return true;
		}
	}

	[SerializeField]
	private float speed;

	private List<PowerUp> weapons;

	private void Awake ()
	{
		weapons = new List<PowerUp> ();
	}

	public void Shoot()
	{
		SpawnBullet ();
		List<PowerUp > toRemove= new List<PowerUp> ();
		foreach (PowerUp decorator in weapons) 
		{
			decorator.Shoot ();
			if (!decorator.HasAmmo) 
			{
				toRemove.Add (decorator);
				Destroy (decorator);
			}
		}

		foreach (PowerUp removed in toRemove) 
		{
			weapons.Remove (removed);
		}
	}

	private void SpawnBullet()
	{
		BulletMove.Spawn (transform.position, transform.rotation);
	}

	public void AddDoubleCanon()
	{
		if (weapons.Find ((powerUp) => powerUp  is DoubleCanon) == null) 
		{
			PowerUp toAdd = gameObject.AddComponent <DoubleCanon> ();
			weapons.Add (toAdd);
			toAdd.Ammo = 30;
		}
	}

	public void AddTripleCanon()
	{
		if (weapons.Find ((powerUp) => powerUp  is TripleCanon) == null) 
		{
			PowerUp toAdd = gameObject.AddComponent <TripleCanon> ();
			weapons.Add (toAdd);
			toAdd.Ammo = 20;
		}
	}
}
