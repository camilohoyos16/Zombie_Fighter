using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement ;

public class GoScene : MonoBehaviour {

	public float timeForChange;
	public string nameOfScene;
	private AudioSource audio;

	void Start () {		

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ButtonClick()
	{
		SceneManager.LoadScene (nameOfScene);
	}


	public IEnumerator MainMenu()
	{
		yield return new WaitForSeconds (timeForChange);
		SceneManager.LoadScene (nameOfScene);
		StopAllCoroutines ();
	}

	public void ChangeScene()
	{if (SceneManager.GetActiveScene().name .Equals("3_Choose Emperador"))
		audio.Play ();
		StartCoroutine (MainMenu ());
	}
}
