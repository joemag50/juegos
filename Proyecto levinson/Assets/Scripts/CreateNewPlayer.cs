using UnityEngine;
using System.Collections;

public class CreateNewPlayer : MonoBehaviour {

	public GameObject nuevoObjeto;
	// Use this for initialization
	void Start () {
		Instantiate(nuevoObjeto, transform.position, transform.rotation);
	}
}
