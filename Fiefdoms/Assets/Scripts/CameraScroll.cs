using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

	float speed = 7f;
	float boundary = 25f;
	float zoomSpeed = 15f;
	int width;
	int height;

	void Start () {
		width = Screen.width;
		height = Screen.height;

	}

	void Update () {
		if (Input.mousePosition.x > width - boundary)
		{
			gameObject.transform.position += new Vector3 (Time.deltaTime * speed,0,0);
		}


		if (Input.mousePosition.y > height - boundary)
		{
			gameObject.transform.position += new Vector3 (0, 0, Time.deltaTime * speed);
		}

	
		if (Input.mousePosition.x <= 0) {
			gameObject.transform.position -= new Vector3 (Time.deltaTime * speed,0,0);
		}
		if (Input.mousePosition.y <= 0) {
			gameObject.transform.position -= new Vector3 (0,0,Time.deltaTime*speed);
		}

		if (Input.GetAxis("Mouse ScrollWheel")>0 && gameObject.transform.position.y>5) {
			gameObject.transform.position -= new Vector3 (0, Time.deltaTime * zoomSpeed, 0);
		}
		if (Input.GetAxis("Mouse ScrollWheel")<0 && gameObject.transform.position.y < 25) {
			gameObject.transform.position += new Vector3 (0, Time.deltaTime * zoomSpeed, 0);
		}

	}

}
