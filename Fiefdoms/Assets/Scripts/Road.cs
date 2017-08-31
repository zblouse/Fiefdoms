using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour {

	public bool placed = false;
	private bool destroying=false;
	private bool finished = false;



	void OnTriggerStay(Collider col){
		if (placed) {
			if (col.transform.parent.tag == "House") {
				col.transform.parent.GetComponent<House> ().RoadAccess = true;
			} else if (col.transform.parent.tag == "Mill") {
				col.transform.parent.GetComponent<Mill> ().RoadAccess = true;
			} else if (col.transform.parent.tag == "LumberYard") {
				col.transform.parent.GetComponent<LumberYard> ().RoadAccess = true;
			} else if (col.transform.parent.tag == "Quarry") {
				col.transform.parent.GetComponent<Quarry> ().RoadAccess = true;
			}else if (col.transform.parent.tag == "Market") {
				col.transform.parent.GetComponent<Market> ().RoadAccess = true;
			}else if (col.transform.parent.tag == "TradeDepo") {
				col.transform.parent.GetComponent<TradeDepo> ().RoadAccess = true;
			}else if (col.transform.parent.tag == "Well") {
				col.transform.parent.GetComponent<Well> ().RoadAccess = true;
			}else if (col.transform.parent.tag == "Inn") {
				col.transform.parent.GetComponent<Inn> ().RoadAccess = true;
			}else if (col.transform.parent.tag == "Church") {
				col.transform.parent.GetComponent<Church> ().RoadAccess = true;
			}
		}
	}
	void OnTriggerExit(Collider col){
		if (placed) {
			if (col.transform.parent.tag == "House") {
				col.transform.parent.GetComponent<House> ().RoadAccess = false;
			} else if (col.transform.parent.tag == "Mill") {
				col.transform.parent.GetComponent<Mill> ().RoadAccess = false;
			} else if (col.transform.parent.tag == "LumberYard") {
				col.transform.parent.GetComponent<LumberYard> ().RoadAccess = false;
			} else if (col.transform.parent.tag == "Quarry") {
				col.transform.parent.GetComponent<Quarry> ().RoadAccess = false;
			}else if (col.transform.parent.tag == "Market") {
				col.transform.parent.GetComponent<Market> ().RoadAccess = false;
			}else if (col.transform.parent.tag == "TradeDepo") {
				col.transform.parent.GetComponent<TradeDepo> ().RoadAccess = false;
			}else if (col.transform.parent.tag == "Well") {
				col.transform.parent.GetComponent<Well> ().RoadAccess = false;
			}else if (col.transform.parent.tag == "Inn") {
				col.transform.parent.GetComponent<Inn> ().RoadAccess = false;
			}else if (col.transform.parent.tag == "Church") {
				col.transform.parent.GetComponent<Church> ().RoadAccess = false;
			}
		}
	}
	public void Update(){
		if (finished) {
			Destroy (gameObject);
		}
		if (destroying) {
			gameObject.GetComponent<BoxCollider> ().center = new Vector3 (0, 100, 0);
			finished = true;
		}
	}
	public void DestroyRoad(){
		destroying = true;
	}
}
