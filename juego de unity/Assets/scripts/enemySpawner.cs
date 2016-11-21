using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;
	public float delayTimer = 1f;
	float timer;

	void Start ()
	{
		timer = delayTimer;
	}
	// Update is called once per frame
	void Update ()
	{
		timer -= Time.deltaTime;
		if(timer <= 0)
		{
			float screenRatio = (float)Screen.width / (float)Screen.height;
			float widthOrtho = Camera.main.orthographicSize * screenRatio;
			Vector3 posisionRandom = new Vector3(Random.Range(-widthOrtho, widthOrtho), transform.position.y, transform.position.z); 
			Instantiate(enemyPrefab, posisionRandom, Quaternion.identity);
			timer = delayTimer;
		}
	}
}
