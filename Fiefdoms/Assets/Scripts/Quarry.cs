﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarry : MonoBehaviour {
	PlayerResources resources;
	ElapsedTime eTime;
	PopulationManager PopManager;
	PauseGame pause;

	public bool RoadAccess;
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
		if (RoadAccess) {
			if (!pause.GamePaused) {
				if (eTime.NewMonth  && CurrentEmployees > 0) {
					resources.PlayerStone = resources.PlayerStone + CurrentEmployees;
				}
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