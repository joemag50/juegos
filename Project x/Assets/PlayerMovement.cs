using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public bool isRunning;
	float velocidad;
	float nextDash = 0.5f;
	float deltaDash = 2f;
	float runningCoolDown = 0f;
	float nextAttack = 0.5f;
	float deltaAttack = 1f;
	float attackCoolDown = 0f;
	//
	Rigidbody2D rbody;
	Animator anim;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		velocidad = 1;
		runningCoolDown = runningCoolDown + Time.deltaTime;
		attackCoolDown = attackCoolDown + Time.deltaTime;
		Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal") * 20, Input.GetAxisRaw("Vertical") * 20);
		if (movement_vector != Vector2.zero){
			anim.SetBool("iswalking", true);
			anim.SetFloat("input_x", movement_vector.x);
			anim.SetFloat("input_y", movement_vector.y);
			//Aqui puedo poner algo en el gui para mostrar que ya puedes saltar
			if(runningCoolDown > nextDash){
				//Debug.Log("Salta");
			}else{
				//Debug.Log("No");
			}
			//Para dash
			if (Input.GetButtonDown("Fire1") && (runningCoolDown > nextDash)){
				nextDash = runningCoolDown + deltaDash;
				velocidad = 20;
				isRunning = true;
				nextDash = nextDash - runningCoolDown;
				runningCoolDown = 0f;
			}
		}else{
			anim.SetBool("iswalking", false);
			isRunning = false;
		}
		//Ataque
		if (Input.GetButtonDown("Fire2") && (attackCoolDown > nextAttack)){
			Debug.Log("Ataque");
			nextAttack = attackCoolDown + deltaAttack;
			nextAttack = nextAttack - attackCoolDown;
			attackCoolDown = 0f;
		}
		rbody.MovePosition(rbody.position + movement_vector * Time.deltaTime * velocidad);
	}
}
