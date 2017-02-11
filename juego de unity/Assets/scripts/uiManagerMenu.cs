using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManagerMenu : MonoBehaviour
{
	// Por si se salen durante el menu de inicio
	void Update ()
	{
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
	//Boton de inicio
	public void Play()
	{
		SceneManager.LoadScene("JuegoMain");
	}
}
