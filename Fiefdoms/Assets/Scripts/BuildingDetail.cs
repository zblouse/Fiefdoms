using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingDetail : MonoBehaviour {
	public PlaceBuilding PlaceBuilding;
	public TradePanel trade;


	public GameObject DetailPanel;
	public Text BuildingNameText;
	public Text DetailText;
	// Use this for initialization
	void Start () {
		DetailPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (!PlaceBuilding.placing) {
			if (Input.GetMouseButtonDown (0)) {
				
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, 100f)) {
					if (hit.transform.tag == "Untagged") {
						if (hit.transform.parent.transform.tag == "House") {
							DetailPanel.SetActive (true);
							BuildingNameText.text = "House";
							if (hit.transform.parent.transform.GetComponent<House> ().MarketAccess) {
								if (hit.transform.parent.transform.GetComponent<House> ().RoadAccess) {
									DetailText.text = "Residents: " + hit.transform.parent.transform.GetComponent<House> ().CurrentPeople + "/" + hit.transform.parent.transform.GetComponent<House> ().maxPeople;
								} else {
									DetailText.text = "Residents: " + hit.transform.parent.transform.GetComponent<House> ().CurrentPeople + "/" + hit.transform.parent.transform.GetComponent<House> ().maxPeople + "\nNo Road Access";
								}
							} else {
								if (hit.transform.parent.transform.GetComponent<House> ().RoadAccess) {
									DetailText.text = "Residents: " + hit.transform.parent.transform.GetComponent<House> ().CurrentPeople + "/" + hit.transform.parent.transform.GetComponent<House> ().maxPeople+"\nNo Market Access";
								} else {
									DetailText.text = "Residents: " + hit.transform.parent.transform.GetComponent<House> ().CurrentPeople + "/" + hit.transform.parent.transform.GetComponent<House> ().maxPeople + "\nNo Road Access\nNo Market Access";
								}
							}
						} else if (hit.transform.parent.transform.tag == "Mill") {
							DetailPanel.SetActive (true);

							BuildingNameText.text="Mill";
							if (hit.transform.parent.transform.GetComponent<Mill> ().RoadAccess) {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Mill> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Mill> ().MaxEmployees;
								Debug.Log ("Current: " + hit.transform.parent.transform.GetComponent<Mill> ().CurrentEmployees);
							} else {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Mill> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Mill> ().MaxEmployees+"\nNo Road Access";
							}

						}  else if (hit.transform.parent.transform.tag == "LumberYard") {
							DetailPanel.SetActive (true);

							BuildingNameText.text="Lumber Yard";
							if (hit.transform.parent.transform.GetComponent<LumberYard> ().RoadAccess) {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<LumberYard> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<LumberYard> ().MaxEmployees;
							} else {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<LumberYard> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<LumberYard> ().MaxEmployees+"\nNo Road Access";
							}

						} else if (hit.transform.parent.transform.tag == "Quarry") {
							DetailPanel.SetActive (true);

							BuildingNameText.text="Quarry";
							if (hit.transform.parent.transform.GetComponent<Quarry> ().RoadAccess) {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Quarry> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Quarry> ().MaxEmployees;
							} else {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Quarry> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Quarry> ().MaxEmployees+"\nNo Road Access";
							}

						}else if (hit.transform.parent.transform.tag == "Field") {
							DetailPanel.SetActive (true);
							BuildingNameText.text="Field";
							DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Field> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Field> ().MaxEmployees;
						}else if (hit.transform.parent.transform.tag == "Market") {
							DetailPanel.SetActive (true);

							BuildingNameText.text="Market";
							if (hit.transform.parent.transform.GetComponent<Market> ().RoadAccess) {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Market> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Market> ().MaxEmployees;
							} else {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Market> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Market> ().MaxEmployees+"\nNo Road Access";
							}

						}else if (hit.transform.parent.transform.tag == "TradeDepo") {
							DetailPanel.SetActive (true);
							trade.ShowDialog ();
							BuildingNameText.text="Trade Depo";
							if (hit.transform.parent.transform.GetComponent<TradeDepo> ().RoadAccess) {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<TradeDepo> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<TradeDepo> ().MaxEmployees;
							} else {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<TradeDepo> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<TradeDepo> ().MaxEmployees+"\nNo Road Access";
							}
						}else if (hit.transform.parent.transform.tag == "Well") {
							DetailPanel.SetActive (true);

							BuildingNameText.text="Well";
							if (hit.transform.parent.transform.GetComponent<Well> ().RoadAccess) {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Well> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Well> ().MaxEmployees;
							} else {
								DetailText.text = "Workers: " + hit.transform.parent.transform.GetComponent<Well> ().CurrentEmployees + "/" + hit.transform.parent.transform.GetComponent<Well> ().MaxEmployees+"\nNo Road Access";
							}
						}

					}
				}
			} else if (Input.GetMouseButtonDown (1)) {
				DetailPanel.SetActive (false);
			}
		}
	}
}
