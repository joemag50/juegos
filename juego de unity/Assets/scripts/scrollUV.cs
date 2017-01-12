using UnityEngine;
using System.Collections;

public class scrollUV : MonoBehaviour {

	public float speed;
	Vector2 offset;
	// Use this for initialization
	void Start ()
	{
		InvokeRepeating("Speed",15.0f,8f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log(Time.time);
		offset = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;		
	}

	void Speed ()
	{
		speed = speed + 0.25f;
	}
}
