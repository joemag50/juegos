using UnityEngine;
using System.Collections;

public class hotcake : MonoBehaviour {

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
