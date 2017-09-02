using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour {

	PlayerResources resources;
	ElapsedTime eTime;
	PopulationManager PopManager;
	PauseGame pause;

	public bool RoadAccess;
	public int MaxEmployees = 5;
	public int CurrentEmployees=0;
	int newWorkers;
	public bool placed=false;

	private bool destroying=false;
	private bool finished = false;

	// Use this for initialization
	void Start () {
		resources=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PlayerResources>();
		eTime=GameObject.FindGameObjectWithTag("Game Control").GetComponent<ElapsedTime>();
		PopManager = GameObject.FindGameObjectWithTag("Game Control").GetComponent<PopulationManager>();
		pause = GameObject.FindGameObjectWithTag("Game Control").GetComponent<PauseGame>();
	}

	// Update is called once per frame
	void Update () {
		if (finished) {
			Destroy (gameObject);
		}
		if (destroying) {
			gameObject.GetComponent<BoxCollider> ().center = new Vector3 (0, 100, 0);
			finished = true;
		}
		if (placed) {
			if (RoadAccess) {
				if (!pause.GamePaused) {
					if (CurrentEmployees < MaxEmployees && placed) {
						newWorkers = PopManager.RequestWorkers (MaxEmployees - CurrentEmployees);
						PopManager.EmployedPeople += newWorkers;
						CurrentEmployees += newWorkers;
						SaveFileControl.control.buildings [gameObject.GetComponent<Building> ().BuildingNum, 4] = CurrentEmployees;
					}
				}
			} else {
				PopManager.EmployedPeople -= CurrentEmployees;
				CurrentEmployees = 0;
				SaveFileControl.control.buildings [gameObject.GetComponent<Building> ().BuildingNum, 4] = CurrentEmployees;
			}
		}
	}
	void OnTriggerStay(Collider col){
		if (placed && CurrentEmployees!=0) {
			if (col.transform.parent.tag == "House") {
				col.transform.parent.GetComponent<House> ().WellAccess = true;
			}
		}
	}
	void OnTriggerExit(Collider col){
		if (placed && CurrentEmployees !=0) {
			if (col.transform.parent.tag == "House") {
				col.transform.parent.GetComponent<House> ().WellAccess = false;
			}
		}
	}

	public void DestroyWell(){
		destroying = true;
	}
}
