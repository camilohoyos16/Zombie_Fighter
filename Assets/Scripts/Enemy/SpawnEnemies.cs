using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public float timeToSpawn;
	private bool canSpawn=true;
	private GameManager gameManager;
	[SerializeField]
	private static int howManySpawns;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("GameManager").GetComponent <GameManager> ();
		howManySpawns = 0;
		GameManager.nextRound += ResetAccountant;
	}
	
	// Update is called once per frame
	void Update () {
		if (canSpawn && howManySpawns < gameManager.enemiesPerRound ) {				
			canSpawn = false;
			StartCoroutine (Spawn ());
		}
			 
	}

	void OnEnable()
	{
		canSpawn = true;
		StopAllCoroutines ();
	}

	IEnumerator Spawn()
	{				
		howManySpawns++;
		Enemy.Spawn (transform.position, transform.rotation);
		yield return  new WaitForSeconds (timeToSpawn);
		canSpawn =true;
	}

	private void ResetAccountant()
	{
		howManySpawns = 0;
	}
}
