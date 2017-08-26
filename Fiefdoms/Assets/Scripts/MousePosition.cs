using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour {
	// Use this for initialization


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		if(Physics.Raycast(ray,out hit,100f)){
			gameObject.transform.position = new Vector3 (hit.point.x,0f,hit.point.z);
		}
	}

}
