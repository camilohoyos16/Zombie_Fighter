using UnityEngine;
using System.Collections;

public class TripleCanon : PowerUp {

	protected override void ShootPowerUp()
	{
		Debug.Log ("Forward and back");
		Vector3 position = new Vector3 (player.transform.position.x, player.transform.position.y - 0.35f, player.transform.position.z);
		BulletMove.Spawn (position, player.transform.rotation);
		Vector3 Secondposition = new Vector3 (player.transform.position.x, player.transform.position.y + 0.35f, player.transform.position.z);
		BulletMove.Spawn (Secondposition, player.transform.rotation);
	}
}
