
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

	public int globalLife;
	[SerializeField ]
	private int currentLife;
	[SerializeField ]
	private float speedMovement;
	[SerializeField ]
	private float jumpPower;
	public bool isJumping;
	private GameObject player;
	private Rigidbody rbEnemy;
	private BoxCollider enemyColl;
	private Vector3 vectorToMove;
//	private Transform  pool;

	public delegate void EnemyHit();
	public static event EnemyHit hitEnemy;


	static private List <Enemy> enemiesPool;

	void Awake()
	{
		//DontDestroyOnLoad (this.gameObject);
		isJumping  = false;
		player = GameObject.Find ("Player");
		rbEnemy = GetComponent <Rigidbody > ();
		enemyColl = GetComponent <BoxCollider> ();

		if (enemiesPool == null)
			enemiesPool = new List<Enemy> ();
		enemiesPool.Add (this);

	}

	void Start()
	{
		GameManager.nextRound += ChangeProperties;
//		pool = GameObject.Find ("EnemiesPool").GetComponent <Transform >();
		gameObject.SetActive (false);
	}

	void Update ()
	{
		Walk ();
		if (currentLife <= 0) 
		{
			CallEvent ();
			gameObject.SetActive (false);
			//OnBecameInvisible ();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Bullet") 
		{
			currentLife --;
		}
	}

	private void Walk()
	{
		RaycastHit hit;
		Ray ray = new Ray (transform.position, transform.up);
		//Gizmos.DrawRay(ray );
		if (Physics.Raycast(ray, out hit, 2f)) {
			string objectHit = hit.transform.tag;
			if (objectHit == "Platform" && !isJumping) {				
				Jump ();
			}
		}
	
		vectorToMove = (player.transform.position - transform.position).normalized;
		vectorToMove = new Vector3 ( 0f , rbEnemy.velocity.y, vectorToMove.z *speedMovement );
		rbEnemy.velocity = vectorToMove;
		
	}
	private void Jump()
	{
		if (ChechkPlatforms.Instance.firstLevel) {			
			rbEnemy.velocity = new Vector3 (0, jumpPower, 0);
			enemyColl.enabled = false;
			Debug.Log ("a un paso de la corrutina");
			isJumping = true;
			StartCoroutine (RealCollider ());
		}
	}

	IEnumerator RealCollider()
	{
		
		yield return new WaitForSeconds (0.35f);
		isJumping = false;
		enemyColl.enabled =true ;
		Debug.Log ("entre a la corrutina");
	}

	protected void OnEnable()
	{
		currentLife = globalLife;
	}

//	protected void OnBecameInvisible()
//	{
//		//transform.position = pool.position;
//		gameObject .SetActive (false);
//	}

	static public Enemy Spawn (Vector3 position, Quaternion rotarion)
	{
		foreach (Enemy oneEnemy in enemiesPool )
		{
			if (oneEnemy .gameObject .activeInHierarchy  == false)
			{
				oneEnemy.transform.position = position;
				oneEnemy.transform.rotation = rotarion;

				oneEnemy.gameObject.SetActive (true);

				return oneEnemy;
			}
		}
		return null;
	}


	void CallEvent()
	{
		if (hitEnemy != null)
			hitEnemy ();
	}

	public void ChangeProperties()
	{
		globalLife++;
		speedMovement += 0.3f;
	}

}
