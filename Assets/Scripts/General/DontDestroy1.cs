using UnityEngine;
using System.Collections;

public class DontDestroy1 : MonoBehaviour {

	public static DontDestroy1 instance;


	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy (gameObject);
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
