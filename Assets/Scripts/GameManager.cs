using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private int enemiesAmount;
	private int score;

	public int round;
	public static string gameState;
	public static GameManager  instance;
	public static GameManager Instance{
		get { 
			return instance;
		}
	}

	void Awake()
	{
		if (!instance)
			instance = this;
		else
			Destroy (gameObject);		
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void Restart()
	{
	}

	private void IncreaseScore (int score)
	{
	}

	private void DecreaseScore(int score)
	{
	}

	private void HowManyEnemies()
	{
	}

	public void ShowLife(int life)
	{
	}
}
