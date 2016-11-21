using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManagerMenu : MonoBehaviour
{
	public Text scoreText;
	bool gameOver;
	int score;
	// Use this for initialization
	void Start ()
	{
		score = 0;
		InvokeRepeating("scoreUpdate",1.0f,0.5f);
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void scoreUpdate()
	{
		if(!gameOver)
		{
			score += 1;
		}
	}

	public void gameOverActivated()
	{
		gameOver = true;
	}

	public void Pause()
	{
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
		}
		else if (Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
	}

	public void Play()
	{
		SceneManager.LoadScene("JuegoMain");
	}
	public void Menu()
	{
		SceneManager.LoadScene("mainMenu");
	}
	public void Exit()
	{
		Application.Quit();
	}
}
