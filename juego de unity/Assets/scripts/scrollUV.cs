using UnityEngine;
using System.Collections;

public class scrollUV : MonoBehaviour
{
	public float scrollSpeed;
	private Vector3 startPosition;
	// Use this for initialization
	void Start ()
	{
		startPosition = transform.position;
		InvokeRepeating("Speed", 30f, 20f);
	}
	// Update is called once per frame
	void Update ()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, Camera.main.orthographicSize * 2.0f);
		transform.position = startPosition + Vector3.down * newPosition;
	}
	void Speed()
	{
		scrollSpeed += 2f;
	}
}
