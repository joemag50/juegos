using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicMove : MonoBehaviour {

	private Vector3 targetPosition;  //Vector de objetivo

	const int LEFT_MOUSE_BUTTON = 0;  // Es una constante para que no se vea el cero asi pelon

	//Asignamos la variable que va a tener el componente
	NavMeshAgent agent;
	void Awake(){
		agent = GetComponent<NavMeshAgent>();
	}

	// Use this for initialization
	void Start () {
		targetPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () { 
		//Esta forma esta bien pero como es por posision hace un efecto de cliping raro
		//transform.Translate(mSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, mSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
		//
		//Esta forma funciona tambien muy bien pero esta complicado por que el objeto se acelera muy facil
		//Vector3 movDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		//this.GetComponent<Rigidbody>().AddForce(movDirection * mSpeed, ForceMode.Acceleration);
		//
		//Esta forma es para moverte con el mouse al darle click
		if(Input.GetMouseButton(LEFT_MOUSE_BUTTON))
			SetTargetPosition();
		
		MovePlayer();
	}

	void SetTargetPosition(){
		Plane plane = new Plane(Vector3.up, transform.position);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float point = 0f;

		if(plane.Raycast(ray, out point)){
			targetPosition = ray.GetPoint(point);
		}
	}

	void MovePlayer(){
		agent.SetDestination(targetPosition);
	}

	void OnTriggerEnter(){
		Debug.Log("holoa");
		agent.SetDestination(transform.position);
	}
}
