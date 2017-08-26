using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingCollision : MonoBehaviour {
	public PlaceBuilding PB;
	public GameObject CollisionObject;
/*
	void OnCollisionEnter(Collision col){
		if (col.collider.transform.tag != "Terrain") {
			CollisionObject = col.collider.transform.gameObject;
			PB.collision = true;
			Debug.Log ("Enter Collision");
		} else {
			
		}
	}
	*/
	void OnCollisionExit(Collision col){
		if (col.collider.transform.tag != "Terrain" && !(col.collider.transform.parent.transform.tag=="Road" && gameObject.transform.parent.transform.tag=="Road")) {
			PB.collision = false;
			Debug.Log ("Exit Collision");
		}
	}

	void OnCollisionStay(Collision col){
		if (col.collider.transform.tag != "Terrain"&& !(col.collider.transform.parent.transform.tag=="Road" && gameObject.transform.parent.transform.tag=="Road")) {
			PB.collision = true;
		}
	}
}
