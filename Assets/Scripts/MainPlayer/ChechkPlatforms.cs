using UnityEngine;
using System.Collections;

public class ChechkPlatforms : MonoBehaviour {

	public GameObject[] platforms1Level;
	public GameObject[] platforms2Level;

	public GameObject pointChecker;

	private CharacterController player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent <CharacterController > ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!player.isGrounded) 
		{
			if (pointChecker.transform.position.y > platforms1Level [0].transform.position.y) {
				for (int i = 0; i < platforms1Level.Length; i++) {
					platforms1Level [i].layer = 8;
				}
			} else {
				for (int i = 0; i < platforms1Level.Length; i++) {
					platforms1Level [i].layer = 10;
				}
			}

			if (pointChecker.transform.position.y >= platforms2Level [0].transform.position.y) {
					for (int i = 0; i < platforms2Level.Length; i++) {
						platforms2Level [i].layer = 9;
					}
			} else 
			{
				for (int i = 0; i < platforms2Level.Length; i++) {
					platforms2Level [i].layer = 11;
				}
			}
		}
	}
}