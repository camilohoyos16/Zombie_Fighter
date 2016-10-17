using UnityEngine;
using System.Collections;

public class SpawnPowerUps : MonoBehaviour {

	public GameObject[] powerUps = new GameObject[2];
	private bool canSpawn;

	public float minLong;
	public float maxLong;

	private Rigidbody rbPower1;
	private Rigidbody rbPower2;

	void Awake()
	{
		rbPower1 = powerUps [0].GetComponent <Rigidbody >();
		rbPower2 = powerUps [1].GetComponent <Rigidbody >();
	}

	void Start () {
		canSpawn = true ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canSpawn) 
		{
			canSpawn = false;
			StartCoroutine (SpawnPower ());
		}
	}

	IEnumerator SpawnPower()
	{
		float timeToSpawn = Random.Range (10f, 20f);
		yield return new WaitForSeconds(timeToSpawn);
		canSpawn = true;
		Spawn ();
	}

	private void Spawn()
	{		
		GameObject chosenPower; 
		float largo = Random.Range (minLong, maxLong);
		Vector3 spawnPoint = new Vector3 (4f, 7f,largo);
		float randomPowerUp = Random.Range (0, 2);
		if (randomPowerUp == 0) {
			chosenPower = powerUps [0];
		} else {
			chosenPower = powerUps [1];
		}

		Instantiate (chosenPower, spawnPoint, chosenPower.transform.rotation);
	}
}
