using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	private Transform  player;
	private Vector3 positionCamera;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		positionCamera.z = player.position.z;
		positionCamera.y = player.position.y+1.1f;
		positionCamera.x = transform.position.x;
		transform.position = positionCamera;
	}
}
