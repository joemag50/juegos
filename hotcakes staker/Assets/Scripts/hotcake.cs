using UnityEngine;
using System.Collections;

public class hotcake : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter()
	{
		die();
	}
	
	void die()
	{
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision c)
	{
		var joint = gameObject.AddComponent<FixedJoint>();
		joint.connectedBody = c.rigidbody;
		joint.breakForce = 50;
	}
}
