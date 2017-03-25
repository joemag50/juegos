using UnityEngine;
using System.Collections;

public class plate : MonoBehaviour {

	float speed;
	// Use this for initialization
	void Start ()
	{
	//	offset = 5f;
		speed = 5f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
			{
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, 50,10));
				transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * speed);
			}
		}
	}

	void OnCollisionEnter(Collision c)
	{
		var joint = gameObject.AddComponent<FixedJoint>();
		joint.connectedBody = c.rigidbody;
		joint.breakForce = 50;
	}
}
