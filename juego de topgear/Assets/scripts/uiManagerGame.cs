﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManagerGame : MonoBehaviour
{
	public Text scoreText;
	public Button[] buttons;
	private bool muteActivated = true;
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
		scoreText.text = "Score: " + score;
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
				activity.Call<bool>("moveTaskToBack", true);
			}
			else
			{
				Application.Quit();
			}
		}
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
		foreach(Button button in buttons)
		{
			button.gameObject.SetActive(true);
		}
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
	public void Mute()
	{
		if(muteActivated)
		{
			AudioListener.volume = 0;
			muteActivated = false;
		}
		else
		{
			AudioListener.volume = 0.50f;
			muteActivated = true;
		}
	}
}

 