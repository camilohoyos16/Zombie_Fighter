using UnityEngine;
using System.Collections;

public class ChechkPlatforms : MonoBehaviour {

	public GameObject[] platforms1Level;
	public GameObject[] platforms2Level;

	public GameObject pointChecker;

	//private CharacterController player;
	public bool firstLevel=false;
	public bool secondLevel=false;

	public static ChechkPlatforms instance;
	public static ChechkPlatforms Instance
	{get{ return instance; }
	}

	// Use this for initialization
	void Start () {
		instance = this;
//		player = GameObject.Find ("Player").GetComponent <CharacterController > ();
	}
	
	// Update is called once per frame
	void Update () 
	{		
		
			if (pointChecker.transform.position.y < platforms1Level [0].transform.position.y) {				
				
				firstLevel = false;
				secondLevel = false;

			} else {				
				firstLevel = true;
				secondLevel = false;
				
			}

			if (pointChecker.transform.position.y >= platforms2Level [0].transform.position.y) {				
				secondLevel = true;
				firstLevel = false;
			} 

		CheckLevelPLatforms ();

	}

	public void CheckLevelPLatforms()
	{
		if(!firstLevel && !secondLevel ) {
			for (int i = 0; i < platforms1Level.Length; i++) {
				platforms1Level [i].layer = 10;
			}
		}
		
		if (firstLevel && !secondLevel) {
			for (int i = 0; i < platforms1Level.Length; i++) {
				platforms1Level [i].layer = 8;
			}
			for (int i = 0; i < platforms2Level.Length; i++) {
				platforms2Level [i].layer = 11;
			}
		}
			

		if (!firstLevel && secondLevel) {
			for (int i = 0; i < platforms2Level.Length; i++) {
				platforms2Level [i].layer = 9;
			}
		
		} 
	}

	public void Baja()
	{	
		if (firstLevel) 
		{
			for (int i = 0; i < platforms1Level.Length; i++) {
				platforms1Level [i].layer = 10;
			}
		}
		if (secondLevel) 
		{
			for (int i = 0; i < platforms2Level.Length; i++) {
				platforms2Level [i].layer = 11;
			}
		}
	}
}
