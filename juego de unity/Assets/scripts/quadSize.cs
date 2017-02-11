using UnityEngine;
using System.Collections;

public class quadSize : MonoBehaviour
{
	float quadHeight;
	float quadWidth;
	void Start ()
	{
		// JCGE Medimos el tamaño ortografico y lo acomodamos para el quad
		quadHeight = Camera.main.orthographicSize * 2.0f;
		quadWidth = quadHeight * Screen.width / Screen.height;
		transform.localScale = new Vector3(quadWidth, quadHeight, 1f);
	}
}
