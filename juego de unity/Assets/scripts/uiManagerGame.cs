using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Advertisements;


public class uiManagerGame : MonoBehaviour
{
	public Text scoreText;
	public Text finalScoreText;
	public Text highScoreText;
	public Button[] buttonsOn;
	public Button[] buttonsOff;
	public Button[] buttonTap;
	private bool muteActivated = true;
	public  bool gameOver;
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
		else
		{
			if (PlayerPrefs.GetFloat("Highscore") < score)
			{
				PlayerPrefs.SetFloat("Highscore", score);
			}
			highScoreText.text = "" + PlayerPrefs.GetFloat("Highscore");
			finalScoreText.text = "" + score;
		}
	}
	public void gameOverActivated()
	{
		gameOver = true;
		foreach(Button button in buttonsOn)
		{
			button.gameObject.SetActive(true);
		}
		foreach(Button button in buttonsOff)
		{
			button.gameObject.SetActive(false);
		}
		foreach(Button button in buttonTap)
		{
			button.gameObject.SetActive(false);
		}
		Debug.Log(addHandler.plays);
		if(addHandler.plays > 5)
		{
			addHandler.plays = 0;
			ShowAd();
			//ShowRewardedAd();
		}
		addHandler.plays = addHandler.plays + 1;
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
	public void tapToMove()
	{
		foreach(Button button in buttonTap)
		{
			button.gameObject.SetActive(false);
		}
	}
	// Este es la version sencilla, de que todo en default, y desde unity services decides cual es el default
	public void ShowAd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show();
		}
	}
	//JCGE: en las opciones de unity 5 tiene que estar forzado el mostrar los anuncios en produccion
	// Este es para los anuncios largos de tiempo
	//public void ShowRewardedAd()
	//{
	//	if (Advertisement.IsReady("rewardedVideo"))
	//	{
	//		var options = new ShowOptions { resultCallback = HandleShowResult };
	//		Advertisement.Show("rewardedVideo", options);
	//	}
	//}
	//private void HandleShowResult(ShowResult result)
	//{
	//	switch (result)
	//	{
	//		case ShowResult.Finished:
	//			Debug.Log("The ad was successfully shown.");
	//			//
	//			// YOUR CODE TO REWARD THE GAMER
	//			// Give coins etc.
	//			break;
	//		case ShowResult.Skipped:
	//			Debug.Log("The ad was skipped before reaching the end.");
	//			break;
	//		case ShowResult.Failed:
	//			Debug.LogError("The ad failed to be shown.");
	//			break;
	//	}
	//}
}
