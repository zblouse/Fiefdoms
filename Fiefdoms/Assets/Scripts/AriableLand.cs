using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AriableLand : MonoBehaviour {
	public PlaceBuilding place;
	void OnTriggerStay(Collider col){
		
		if (col.transform.parent.tag == "Field") {
			if(!col.transform.parent.GetComponent<Field> ().placed){
				place.FieldAriable = true;
			}
		}

	}
	void OnTriggerExit(Collider col){

		if (col.transform.parent.tag == "Field") {
			if(!col.transform.parent.GetComponent<Field> ().placed){
				place.FieldAriable = false;
			}
		}
	}
}
