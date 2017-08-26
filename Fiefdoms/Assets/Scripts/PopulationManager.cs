using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationManager : MonoBehaviour {
	public float Unemployment;
	public int jobs;
	public int PlayerPopulation=0;
	public int EmployedPeople=0;
	private int removed = 0;
	private int removeNum=0;
	public GameObject[] buildings = new GameObject[500];


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPopulation > 0) {
			Unemployment = (float)((float)((float)PlayerPopulation-(float)EmployedPeople) / (float)PlayerPopulation);
		} else {
			Unemployment = 0;
		}
		SaveFileControl.control.TotalEmployees = EmployedPeople;

	}

	public int RequestWorkers(int requestedAmmount){
		if ((PlayerPopulation - EmployedPeople) > requestedAmmount) {
			Debug.Log ("Request Filled");
			Debug.Log ("Pop: " + PlayerPopulation + " Emp: " + EmployedPeople);
			return requestedAmmount;

		} else {
			//Debug.Log ("Not Enough");
			return (PlayerPopulation - EmployedPeople);

		}
	}

	public void DecreasePopulation(int DecreaseAmmount){
		Debug.Log ("Decrease Ammount: " + DecreaseAmmount);
		if ((PlayerPopulation - EmployedPeople) < DecreaseAmmount) {
			Debug.Log ("Unemployed less than Decrease Ammount");
			if (EmployedPeople >= DecreaseAmmount) {
				Debug.Log ("More Employed than decrease ammount");
				while (removed != DecreaseAmmount) {
					if (buildings [removeNum] != null) {
						if (buildings [removeNum].tag == "Mill") {
							Debug.Log ("Removed at Mill");
							removed += buildings [removeNum].GetComponent<Mill> ().CurrentEmployees;
							buildings [removeNum].GetComponent<Mill> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [removeNum].GetComponent<Mill> ().CurrentEmployees);
						}
						if (buildings [removeNum].tag == "Market") {
							Debug.Log ("Removed at Market");
							removed += buildings [removeNum].GetComponent<Market> ().CurrentEmployees;
							buildings [removeNum].GetComponent<Market> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [removeNum].GetComponent<Market> ().CurrentEmployees);
						}
						if (buildings [removeNum].tag == "Field") {
							Debug.Log ("Removed at Field");
							removed += buildings [removeNum].GetComponent<Field> ().CurrentEmployees;
							buildings [removeNum].GetComponent<Field> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [removeNum].GetComponent<Field> ().CurrentEmployees);
						}
						if (buildings [removeNum].tag == "LumberYard") {
							Debug.Log ("Removed at Lumber Yard");
							removed += buildings [removeNum].GetComponent<LumberYard> ().CurrentEmployees;
							buildings [removeNum].GetComponent<LumberYard> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [removeNum].GetComponent<LumberYard> ().CurrentEmployees);
						}
						if (buildings [removeNum].tag == "Quarry") {
							Debug.Log ("Removed at Quarry");
							removed += buildings [removeNum].GetComponent<Quarry> ().CurrentEmployees;
							buildings [removeNum].GetComponent<Quarry> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [removeNum].GetComponent<Quarry> ().CurrentEmployees);
						}
					}
					removeNum++;
				}

			} else {
				Debug.Log ("Less Employed than decrease ammount");
				for (int i = 0; i < SaveFileControl.control.BuildingCount; i++) {
					if (buildings [i] != null) {
						Debug.Log ("Remove Num: " + i + "Tag: " + buildings [i].tag);
						if (buildings [i].tag == "Mill") {
							Debug.Log ("Removed at Mill");
							removed += buildings [i].GetComponent<Mill> ().CurrentEmployees;
							buildings [i].GetComponent<Mill> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [i].GetComponent<Mill> ().CurrentEmployees);
						}
						if (buildings [i].tag == "Field") {
							Debug.Log ("Removed at Field");
							removed += buildings [i].GetComponent<Field> ().CurrentEmployees;
							buildings [i].GetComponent<Field> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [i].GetComponent<Field> ().CurrentEmployees);
						}
						if (buildings [i].tag == "LumberYard") {
							Debug.Log ("Removed at LumberYard");
							removed += buildings [i].GetComponent<LumberYard> ().CurrentEmployees;
							buildings [i].GetComponent<LumberYard> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [i].GetComponent<LumberYard> ().CurrentEmployees);
						}
						if (buildings [i].tag == "Quarry") {
							Debug.Log ("Removed at Quarry");
							removed += buildings [i].GetComponent<Quarry> ().CurrentEmployees;
							buildings [i].GetComponent<Quarry> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [i].GetComponent<Quarry> ().CurrentEmployees);
						}
						if (buildings [i].tag == "Market") {
							Debug.Log ("Removed at Market");
							removed += buildings [i].GetComponent<Market> ().CurrentEmployees;
							buildings [i].GetComponent<Market> ().CurrentEmployees = 0;
							Debug.Log ("Current Employees: " + buildings [i].GetComponent<Market> ().CurrentEmployees);
						}
					} else {
						Debug.Log ("Building is null");
					}
				}
			}
		}
		PlayerPopulation = PlayerPopulation - DecreaseAmmount;
		EmployedPeople = EmployedPeople - removed;
		removed = 0;
		removeNum = 0;
	}
}
