﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mill : MonoBehaviour {
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
	void Awake(){
	}
	void Start () {
		resources=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PlayerResources>();
		eTime=GameObject.FindGameObjectWithTag("Game Control").GetComponent<ElapsedTime>();
		PopManager = GameObject.FindGameObjectWithTag("Game Control").GetComponent<PopulationManager>();
		pause = GameObject.FindGameObjectWithTag("Game Control").GetComponent<PauseGame>();
	}
	
	// Update is called once per frame
	void Update () {
		if (placed) {
			if (RoadAccess) {
				if (!pause.GamePaused) {
					if (eTime.NewMonth && resources.PlayerFood >= 25 && CurrentEmployees > 0) {
						resources.PlayerGold = resources.PlayerGold + CurrentEmployees;
						resources.PlayerFood = resources.PlayerFood - 15;

					}
					if (CurrentEmployees < MaxEmployees && placed && eTime.NewMonth) {
						newWorkers = PopManager.RequestWorkers (1);
						PopManager.EmployedPeople += newWorkers;
						CurrentEmployees += newWorkers;
						Debug.Log ("" + gameObject.GetComponent<Building> ().BuildingNum);
						SaveFileControl.control.buildings [gameObject.GetComponent<Building> ().BuildingNum, 4] = CurrentEmployees;
					}
				}
			} else {
				PopManager.EmployedPeople -= CurrentEmployees;
				CurrentEmployees = 0;
				Debug.Log ("" + gameObject.GetComponent<Building> ().BuildingNum);
				SaveFileControl.control.buildings [gameObject.GetComponent<Building> ().BuildingNum, 4] = CurrentEmployees;
			}
		}
	}
}
