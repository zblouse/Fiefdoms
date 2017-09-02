using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScroll : MonoBehaviour {

	float speed = 7f;
	float boundary = 15f;
	float zoomSpeed = 15f;
	float MaxCameraMove;
	int width;
	int height;
	int CameraDirection=1;//1 = north(default), 2 = east, 3 = south, 4= west
	Quaternion north;
	Quaternion south;
	Quaternion east;
	Quaternion west;

	void Start () {
		width = Screen.width;
		height = Screen.height;
		if (SceneManager.GetActiveScene ().name == "test") {
			MaxCameraMove = 10;

		}
		north = Quaternion.Euler (60,0,0);
		south = Quaternion.Euler (60, 180, 0);
		east = Quaternion.Euler (60,90,0);
		west = Quaternion.Euler (60,270,0);
	}

	void Update () {
		if (CameraDirection == 1) {//north
			if (Input.mousePosition.x > width - boundary) {
				if (gameObject.transform.position.x <= MaxCameraMove) {
					gameObject.transform.position += new Vector3 (Time.deltaTime * speed, 0, 0);
				}
			}
			if (Input.mousePosition.y > height - boundary) {
				if (gameObject.transform.position.z <= (MaxCameraMove-7)) {
					gameObject.transform.position += new Vector3 (0, 0, Time.deltaTime * speed);
				}
			}
			if (Input.mousePosition.x <= 0) {
				if (gameObject.transform.position.x >= -MaxCameraMove) {
					gameObject.transform.position -= new Vector3 (Time.deltaTime * speed, 0, 0);
				}
			}
			if (Input.mousePosition.y <= 0) {
				if (gameObject.transform.position.z >= -(MaxCameraMove+6)) {
					gameObject.transform.position -= new Vector3 (0, 0, Time.deltaTime * speed);
				}
			}
		} else if (CameraDirection == 2) {//south
			if (Input.mousePosition.x > width - boundary) {
				if (gameObject.transform.position.x >= -MaxCameraMove) {
					gameObject.transform.position -= new Vector3 (Time.deltaTime * speed, 0, 0);
				}
			}
			if (Input.mousePosition.y > height - boundary) {
				if (gameObject.transform.position.z >= -(MaxCameraMove-7)) {
					gameObject.transform.position -= new Vector3 (0, 0, Time.deltaTime * speed);
				}
			}
			if (Input.mousePosition.x <= 0) {
				if (gameObject.transform.position.x <= MaxCameraMove) {
					gameObject.transform.position += new Vector3 (Time.deltaTime * speed, 0, 0);
				}
			}
			if (Input.mousePosition.y <= 0) {
				if (gameObject.transform.position.z <= (MaxCameraMove+6)) {
					gameObject.transform.position += new Vector3 (0, 0, Time.deltaTime * speed);
				}
			}
		} else if (CameraDirection == 3) {//east
			if (Input.mousePosition.x > width - boundary) {
				if (gameObject.transform.position.z >= -MaxCameraMove) {
					gameObject.transform.position -= new Vector3 (0, 0,Time.deltaTime * speed);
				}
			}
			if (Input.mousePosition.y > height - boundary) {
				if (gameObject.transform.position.x <= (MaxCameraMove-7)) {
					gameObject.transform.position += new Vector3 (Time.deltaTime * speed,0, 0);
				}
			}
			if (Input.mousePosition.x <= 0) {
				if (gameObject.transform.position.z <= MaxCameraMove) {
					gameObject.transform.position += new Vector3 (0, 0,Time.deltaTime * speed);
				}
			}
			if (Input.mousePosition.y <= 0) {
				if (gameObject.transform.position.x >= -(MaxCameraMove+6)) {
					gameObject.transform.position -= new Vector3 (Time.deltaTime * speed, 0, 0);
				}
			}
		} else if (CameraDirection == 4) {//west
			if (Input.mousePosition.x > width - boundary) {
				if (gameObject.transform.position.z <= MaxCameraMove) {
					gameObject.transform.position += new Vector3 (0,0,Time.deltaTime * speed);
				}
			}
			if (Input.mousePosition.y > height - boundary) {
				if (gameObject.transform.position.x >= -(MaxCameraMove-7)) {
					gameObject.transform.position -= new Vector3 (Time.deltaTime * speed,0, 0);
				}
			}
			if (Input.mousePosition.x <= 0) {
				if (gameObject.transform.position.z >= -MaxCameraMove) {
					gameObject.transform.position -= new Vector3 (0, 0,Time.deltaTime * speed);
				}
			}
			if (Input.mousePosition.y <= 0) {
				if (gameObject.transform.position.x <= (MaxCameraMove+6)) {
					gameObject.transform.position += new Vector3 (Time.deltaTime * speed,0, 0);
				}
			}
		}
		if (Input.GetAxis("Mouse ScrollWheel")>0 && gameObject.transform.position.y>5) {
			gameObject.transform.position -= new Vector3 (0, Time.deltaTime * zoomSpeed, 0);
		}
		if (Input.GetAxis("Mouse ScrollWheel")<0 && gameObject.transform.position.y < 25) {
			gameObject.transform.position += new Vector3 (0, Time.deltaTime * zoomSpeed, 0);
		}

	}

	public void PointNorth(){
		CameraDirection = 1;
		gameObject.transform.rotation = north;
	}
	public void PointSouth(){
		CameraDirection = 2;
		gameObject.transform.rotation = south;
	}
	public void PointEast(){
		CameraDirection = 3;
		gameObject.transform.rotation = east;
	}
	public void PointWest(){
		CameraDirection = 4;
		gameObject.transform.rotation = west;
	}

}
