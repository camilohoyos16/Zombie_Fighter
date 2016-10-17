using UnityEngine;
using System.Collections;

public class DoubleCanon : PowerUp  {

	protected override void ShootPowerUp()
	{
		Debug.Log ("double canon");
		Vector3 position = new Vector3 (player.transform.position.x, player.transform.position.y + 0.35f, player.transform.position.z);
		BulletMove.Spawn (position, player.transform.rotation);
	}
}
