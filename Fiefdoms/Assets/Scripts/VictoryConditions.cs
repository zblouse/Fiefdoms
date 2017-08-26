using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryConditions : MonoBehaviour {
	public int PopulationReq;
	public int DiscontentReq;
	public GameObject VictoryScreen;
	public PauseGame pause;
	public PopulationManager PopMan;
	public Discontent discontent;
	public bool Victory=false;
	// Use this for initialization
	void Start () {
		if (SceneManager.GetActiveScene ().name == "test") {
			PopulationReq = 200;
			DiscontentReq = 20;
		}
		VictoryScreen.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (PopMan.PlayerPopulation >= PopulationReq && discontent.DiscontentAmmt<=DiscontentReq && !Victory) {
			Victory = true;
			VictoryScreen.SetActive (true);
			pause.GamePaused = true;
		}
	}
	public void ContinuePlaying(){
		VictoryScreen.SetActive (false);
		pause.GamePaused = false;
	}



}
