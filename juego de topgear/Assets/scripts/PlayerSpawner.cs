using UnityEngine;
using System.Collections;

public class PlayerSpawner : MonoBehaviour
{

	public GameObject playerPrefab;
	GameObject playerInstance;

	//float respawnTimer;
	// Use this for initialization
	void Start ()
	{
		SpawnPlayer();
	}
	
	void SpawnPlayer()
	{
		//respawnTimer = 1;
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.Euler(50, 0, 0));		
	}
	// Update is called once per frame
	void Update ()
	{
		//Si quieres el jugador reaparesca
		if(playerInstance == null)
		{
		//	respawnTimer -= Time.deltaTime;
		//	if(respawnTimer <= 0)
		//	{
		//		SpawnPlayer();				
		//	}
		}
	}
}
