using UnityEngine;
using System.Collections;
using System .Collections .Generic;
public class BulletMove : MonoBehaviour {

	//private Transform player;
	public float speed;
	private Vector3 moveDirection;
	private Rigidbody rigidbodyBullet;
	static private List <BulletMove> bulletsPool;

	void Awake()
	{
		//player = GameObject.FindGameObjectWithTag ("Player").GetComponent <Transform> ();
		rigidbodyBullet = GetComponent <Rigidbody> ();

		if (bulletsPool == null)
			bulletsPool = new List <BulletMove> ();
		bulletsPool.Add (this);
	}

	void Start () {

		gameObject.SetActive (false);
	}

	void Update () {

	}

	protected void OnEnable()
	{
		rigidbodyBullet.velocity = transform .forward  * speed; 
		StartCoroutine (TimeToDisable ());
	}

	protected void OnBecameInvisible()
	{
		StopAllCoroutines ();
		gameObject.SetActive (false);
	}

	IEnumerator TimeToDisable()
	{
		yield return new WaitForSeconds (2f);
		OnBecameInvisible ();
	}

	static public BulletMove Spawn(Vector3 position, Quaternion rotation)
	{
		foreach (BulletMove singleBullet in bulletsPool) 
		{
			if (singleBullet.gameObject.activeInHierarchy == false) 
			{
				singleBullet.transform.position = position;
				singleBullet.transform.rotation = rotation;

				singleBullet.gameObject.SetActive (true);

				return singleBullet;
			}
		}
		return null; 
	}

	protected void OnDestroy()
	{
		bulletsPool.Remove (this);
		if (bulletsPool.Count == 0)
			bulletsPool = null;
	}

}
