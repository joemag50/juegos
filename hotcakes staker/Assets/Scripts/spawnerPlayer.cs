using UnityEngine;
using System.Collections;

public class spawnerPlayer : MonoBehaviour {

	public GameObject playerPrefab;
	GameObject playerInstance;
	// Use this for initialization
	void Start ()
	{
		SpawnPlayer();
	}
	void SpawnPlayer()
	{
		playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);		
	}
}
