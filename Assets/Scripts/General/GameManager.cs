using UnityEngine;
using System.Collections;
using UnityEngine .UI;

public class GameManager : MonoBehaviour {

	public delegate void Round();
	public static event Round nextRound;

	public Text scoreText;
	public Text lifeText;
	public Text roundText;
	public Text enemiesCount;
	public Text gameOverText;

	[SerializeField]
	public int enemiesAmount;
	public int enemiesPerRound;
	private int score;
	private int lifes;

	public int round;
	public static GameManager  instance;
	public static GameManager Instance{
		get { 
			return instance;
		}
	}

	//Enemy enemy = new Enemy ();

	void Awake()
	{
		score = 0;
		lifes = 10;
		round = 1;
		enemiesPerRound = 5;
		if (!instance)
			instance = this;
		else
			Destroy (gameObject);		
	}

	void Start () {
		PlayerCollisions.playerHit += DecreaseScore;
		PlayerCollisions.playerHit += LoseLife;
		PlayerCollisions.playerHit += DecreaseScore;

		Enemy.hitEnemy += IncreaseScore;
		Enemy.hitEnemy += HowManyEnemies;
	}
	
	// Update is called once per frame
	void Update () {
		ShowTexts ();

		if (enemiesAmount <= 0)
			NextRound ();
		if (lifes < 1)
			GameOver ();
		
	}

	private void GameOver()
	{
		gameOverText.gameObject.SetActive (true);
		Time.timeScale = 0;
	}

	private void IncreaseScore ()
	{
		score += 10;
	}

	private void DecreaseScore()
	{
		score -= 10;
	}

	private void HowManyEnemies()
	{
		enemiesAmount--;

	}

	void NextRound()
	{
		if (nextRound != null)
			nextRound ();
		round++;
		enemiesPerRound += 2;
		enemiesAmount = enemiesPerRound;
	}

	private void LoseLife()
	{
		lifes--;
	}

	public void ShowTexts()
	{
		lifeText .text = "Lifes: " + lifes;
		scoreText.text = "Score: " + score;
		roundText.text = "Round: " + round;
		enemiesCount.text = "Enemies: " + enemiesAmount;
	}
}
