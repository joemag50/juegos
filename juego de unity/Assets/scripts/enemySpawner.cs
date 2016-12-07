using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour
{

	public GameObject enemyPrefab;
	public float delayTimer = 0.5f;

	void Start ()
	{
		InvokeRepeating("Spawn",delayTimer,delayTimer);
		InvokeRepeating("Spawn",delayTimer + 0.8f,delayTimer + 0.7f);
		InvokeRepeating("Spawn",delayTimer + 1.2f,delayTimer + 1.4f);
		InvokeRepeating("Spawn",delayTimer + 1.7f,delayTimer + 0.9f);
	}
	// Update is called once per frame
	void Spawn ()
	{
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;
		Vector3 posisionRandom = new Vector3(Random.Range(-widthOrtho, widthOrtho), transform.position.y, transform.position.z); 
		Instantiate(enemyPrefab, posisionRandom, Quaternion.identity);
	}
}
