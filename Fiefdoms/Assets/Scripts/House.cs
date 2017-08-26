using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
	public int maxPeople=20;
	public int CurrentPeople=0;
	public float desireability;
	float GrowthModifier=0;
	float maxThisTurn;
	public PopulationManager PopManager;
	public int thisTurnPopChange;
	public bool Placed=false;

	public PlayerResources pResource;
	public Discontent discontent;

	public bool RoadAccess = false;
	public bool MarketAccess = false;

	public ElapsedTime ElapsedTime;
	// Use this for initialization
	void Start () {
		desireability = 1;
		PopManager=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PopulationManager>();
		ElapsedTime=GameObject.FindGameObjectWithTag("Game Control").GetComponent<ElapsedTime>();
		discontent=GameObject.FindGameObjectWithTag("Game Control").GetComponent<Discontent>();
		pResource=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PlayerResources>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (RoadAccess) {

			if (Placed && ElapsedTime.NewMonth) {
				if (PopManager.Unemployment < .05) {
					GrowthModifier = 5;
				} else if (PopManager.Unemployment < .1) {
					GrowthModifier = 3;
				} else if (PopManager.Unemployment < .15) {
					GrowthModifier = 1;
				} else if (PopManager.Unemployment < .2) {
					GrowthModifier = 0;
				} else if (PopManager.Unemployment < .3) {
					GrowthModifier = -1;
				} else if (PopManager.Unemployment < .4) {
					GrowthModifier = -3;
				} else if (PopManager.Unemployment < .6) {
					GrowthModifier = -5;
				} else {
					GrowthModifier = -10;
				}
				GrowthModifier += desireability;
				maxThisTurn = maxPeople - CurrentPeople;
				if (CurrentPeople < maxPeople) {
					thisTurnPopChange = (int)Random.Range (GrowthModifier, maxThisTurn);
					if (CurrentPeople + thisTurnPopChange > maxPeople) {
						thisTurnPopChange = maxPeople - CurrentPeople;
						CurrentPeople = maxPeople;
					} else {
						CurrentPeople += thisTurnPopChange;
					}
					if (CurrentPeople < 0) {
						CurrentPeople = 0;
					}
					SaveFileControl.control.buildings [gameObject.GetComponent<Building> ().BuildingNum, 4] = CurrentPeople;
					PopManager.PlayerPopulation += thisTurnPopChange;

				}

				if (MarketAccess) {
					if (pResource.PlayerFood - CurrentPeople >= 0) {
						pResource.PlayerFood = (pResource.PlayerFood - CurrentPeople);
						if (discontent.DiscontentAmmt > 0) {
							discontent.DiscontentAmmt -= .25f;
						}
					} else {
						discontent.DiscontentAmmt += 2;
						pResource.PlayerFood = 0;
					}
				} else {
					discontent.DiscontentAmmt += 3;
				}
			}
		} else {
			if (CurrentPeople > 0) {
				PopManager.DecreasePopulation (CurrentPeople);
				CurrentPeople = 0;
			}
		}
	}
}
