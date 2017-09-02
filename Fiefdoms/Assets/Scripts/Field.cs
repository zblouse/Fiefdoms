using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour {

	PlayerResources resources;
	ElapsedTime eTime;
	PopulationManager PopManager;
	PauseGame pause;
	public int MaxEmployees = 10;
	public int CurrentEmployees=0;
	int newWorkers;
	public bool placed=false;
	// Use this for initialization
	void Start () {
		resources=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PlayerResources>();
		eTime=GameObject.FindGameObjectWithTag("Game Control").GetComponent<ElapsedTime>();
		PopManager = GameObject.FindGameObjectWithTag("Game Control").GetComponent<PopulationManager>();
		pause = GameObject.FindGameObjectWithTag("Game Control").GetComponent<PauseGame>();

	}

	// Update is called once per frame
	void Update () {
		if (!pause.GamePaused && placed) {
			if (eTime.NewMonth && (eTime.currentMonth>=4 && eTime.currentMonth<=11)) {
				resources.PlayerFood += CurrentEmployees * 2;


			}
			if (CurrentEmployees < MaxEmployees && placed) {
				newWorkers = PopManager.RequestWorkers (MaxEmployees - CurrentEmployees);
				PopManager.EmployedPeople += newWorkers;
				CurrentEmployees += newWorkers;
				SaveFileControl.control.buildings [gameObject.GetComponent<Building> ().BuildingNum, 4] = CurrentEmployees;
			}
		}
	}
}
