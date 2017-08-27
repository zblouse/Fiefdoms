using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBuilding : MonoBehaviour {
	public PlaceBuilding pBuilding;
	public PopulationManager PopMan;
	public bool Removing = false;
	// Use this for initialization


	void Update(){
		if (Removing && Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100f)) {
				if (hit.collider.gameObject.transform.parent != null) {
					if (hit.collider.gameObject.transform.parent.tag == "House") {
						PopMan.DecreasePopulation (hit.collider.gameObject.transform.parent.GetComponent<House> ().CurrentPeople);
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum] = null;
						Destroy (hit.collider.gameObject.transform.parent.gameObject);
					} else if (hit.collider.gameObject.transform.parent.tag == "Mill") {
						PopMan.EmployedPeople = PopMan.EmployedPeople - hit.collider.gameObject.transform.parent.GetComponent<Mill> ().CurrentEmployees;
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum] = null;
						Destroy (hit.collider.gameObject.transform.parent.gameObject);
					} else if (hit.collider.gameObject.transform.parent.tag == "Field") {
						PopMan.EmployedPeople = PopMan.EmployedPeople - hit.collider.gameObject.transform.parent.GetComponent<Field> ().CurrentEmployees;
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum] = null;
						Destroy (hit.collider.gameObject.transform.parent.gameObject);
					} else if (hit.collider.gameObject.transform.parent.tag == "LumberYard") {
						PopMan.EmployedPeople = PopMan.EmployedPeople - hit.collider.gameObject.transform.parent.GetComponent<LumberYard> ().CurrentEmployees;
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum] = null;
						Destroy(hit.collider.gameObject.transform.parent.gameObject);
					} else if (hit.collider.gameObject.transform.parent.tag == "Quarry") {
						PopMan.EmployedPeople = PopMan.EmployedPeople - hit.collider.gameObject.transform.parent.GetComponent<Quarry> ().CurrentEmployees;
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum] = null;
						Destroy (hit.collider.gameObject.transform.parent.gameObject);
					}else if (hit.collider.gameObject.transform.parent.tag == "Market") {
						pBuilding.MarketCount--;
						PopMan.EmployedPeople = PopMan.EmployedPeople - hit.collider.gameObject.transform.parent.GetComponent<Market> ().CurrentEmployees;
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum].GetComponent<Market> ().DestroyMarket ();
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum] = null;
					}else if (hit.collider.gameObject.transform.parent.tag == "TradeDepo") {
						PopMan.EmployedPeople = PopMan.EmployedPeople - hit.collider.gameObject.transform.parent.GetComponent<TradeDepo> ().CurrentEmployees;
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.parent.GetComponent<Building> ().BuildingNum] = null;
						Destroy (hit.collider.gameObject.transform.parent.gameObject);
					} else {
						Debug.Log (hit.collider.gameObject.transform.parent.tag);
					}
				} else {
					if (hit.collider.gameObject.transform.tag == "Road") {
						SaveFileControl.control.buildings [hit.collider.gameObject.transform.GetComponent<Building> ().BuildingNum, 3] = 0;
						PopMan.buildings [hit.collider.gameObject.transform.GetComponent<Building> ().BuildingNum].GetComponent<Road> ().DestroyRoad ();
						PopMan.buildings [hit.collider.gameObject.transform.GetComponent<Building> ().BuildingNum] = null;


					}
				}

			}

		} else if (Removing && Input.GetMouseButtonDown (1)) {
			Removing = false;
		}
	}

	public void RemoveSelect(){
		if (pBuilding.placing) {
			pBuilding.EndPlacement ();
			Removing = true;
		} else {
			Removing = true;
		}
	}
	public void EndRemoving(){
		if (Removing) {
			Removing = false;
		}
	}
}
