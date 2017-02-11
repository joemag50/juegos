using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour
{
	public GameObject[] enemyPrefabs;
	public float delayTimer = 0.5f;
	int carNo;
	void Start ()
	{
		InvokeRepeating("Spawn",delayTimer,delayTimer);
		InvokeRepeating("Spawn",20.0f,0.9f);
		InvokeRepeating("Spawn",30.0f,0.7f);
	}
	// Update is called once per frame
	void Spawn ()
	{
		float screenRatio = (float)Screen.width / (float)Screen.height;
		float widthOrtho = Camera.main.orthographicSize * screenRatio;
		carNo = Random.Range(0,7);
		Vector3 posisionRandom = new Vector3(Random.Range((int)-widthOrtho, (int)widthOrtho + 1), transform.position.y, transform.position.z); 
		Instantiate(enemyPrefabs[carNo], posisionRandom, Quaternion.identity);
	}
}
