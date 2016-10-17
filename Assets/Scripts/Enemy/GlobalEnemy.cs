using UnityEngine;
using System.Collections;

public class GlobalEnemy : MonoBehaviour {

	//[SerializeField ]
	public int globalLife;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int ModifieLife
	{
		get {
			return globalLife;
		}

		set {
			globalLife = value ;
		}
	}
}
