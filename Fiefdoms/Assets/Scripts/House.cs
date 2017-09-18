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

	private PlayerResources pResource;
	private Discontent discontent;
	private ElapsedTime ElapsedTime;
	private Prosperity prosp;

	public bool RoadAccess = false;
	public bool MarketAccess = false;
	public bool WellAccess=false;
	public bool InnAccess=false;
	public bool ChurchAccess = false;

	public int HouseLevel;
	public GameObject Level2Model;
	public GameObject Level3Model;
	private bool Upgrading = false;

	private GameObject newModel;



	// Use this for initialization
	void Start () {
		
		desireability = 1;
		HouseLevel = 1;
		Level2Model = GameObject.FindGameObjectWithTag ("Game Control").GetComponent<HouseModels> ().House2;
		Level3Model = GameObject.FindGameObjectWithTag ("Game Control").GetComponent<HouseModels> ().House3;
		PopManager=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PopulationManager>();
		ElapsedTime=GameObject.FindGameObjectWithTag("Game Control").GetComponent<ElapsedTime>();
		discontent=GameObject.FindGameObjectWithTag("Game Control").GetComponent<Discontent>();
		pResource=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PlayerResources>();
		prosp=GameObject.FindGameObjectWithTag("Game Control").GetComponent<Prosperity>();
	}
	
	// Update is called once per frame
	void Update () {
		if (RoadAccess||Upgrading) {

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
				if (HouseLevel == 1) {
					if (pResource.PlayerFood - (int)(CurrentPeople/2) >= 0) {
						pResource.PlayerFood = (pResource.PlayerFood - (int)(CurrentPeople/2));
						if (discontent.DiscontentAmmt > 0) {
							discontent.DiscontentAmmt -= .25f;
						}
					} else {
						discontent.DiscontentAmmt += 2;
						pResource.PlayerFood = 0;
					}

					if (MarketAccess && WellAccess) {
						Debug.Log ("Upgrading to Level 2");
						Destroy (gameObject.transform.GetChild (0).gameObject);
						newModel = Instantiate (Level2Model, gameObject.transform);
						newModel.transform.localPosition = new Vector3 (0, .5f, 0);
						newModel.GetComponent<PlacingCollision> ().PB = GameObject.FindGameObjectWithTag ("Game Control").GetComponent<PlaceBuilding> ();
						SaveFileControl.control.buildings [gameObject.GetComponent<Building> ().BuildingNum, 5] = 2;//House Level
						maxPeople = 25;
						HouseLevel = 2;
						prosp.ProsperityAmmt += .25f;
						Upgrading = true;
					}
				}else if (HouseLevel == 2) {
					if (Upgrading) {
						Upgrading = false;
					}
					if (HouseLevel == 2 && MarketAccess && WellAccess && InnAccess && ChurchAccess) {
						Upgrading = true;
						Debug.Log ("Upgrading to Level 3");
						Destroy (gameObject.transform.GetChild (0).gameObject);
						newModel = Instantiate (Level3Model,gameObject.transform);
						newModel.transform.localPosition = new Vector3 (0,.5f,0);
						newModel.GetComponent<PlacingCollision>().PB=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PlaceBuilding>();
						SaveFileControl.control.buildings[gameObject.GetComponent<Building>().BuildingNum, 5] = 3;//House Level
						maxPeople=30;
						HouseLevel = 3;
						prosp.ProsperityAmmt += .25f;
					}
					if (MarketAccess) {
						if (pResource.PlayerFood - (2*CurrentPeople) >= 0) {
							pResource.PlayerFood = (pResource.PlayerFood - (2*CurrentPeople));
							if (discontent.DiscontentAmmt > 0) {
								discontent.DiscontentAmmt -= .25f;
							}
						} else {
							discontent.DiscontentAmmt += 2;
							pResource.PlayerFood = 0;
						}
					} else {
						discontent.DiscontentAmmt += 2;
					}
					if (!WellAccess) {
						discontent.DiscontentAmmt += 2;
					}

				}else if (HouseLevel == 3) {
					if (Upgrading) {
						Upgrading = false;
					}
					if (HouseLevel == 2 && MarketAccess && WellAccess && InnAccess && ChurchAccess) { //update needed
						Debug.Log ("Upgrading to Level 3");
						Destroy (gameObject.transform.GetChild (0).gameObject);
						newModel = Instantiate (Level3Model,gameObject.transform);
						newModel.transform.localPosition = new Vector3 (0,1f,0);
						newModel.GetComponent<PlacingCollision>().PB=GameObject.FindGameObjectWithTag("Game Control").GetComponent<PlaceBuilding>();
						SaveFileControl.control.buildings[gameObject.GetComponent<Building>().BuildingNum, 5] = 3;//House Level
						maxPeople=30;
						HouseLevel = 3;
					}
					if (MarketAccess) {
						if (pResource.PlayerFood - (2*CurrentPeople) >= 0) {
							pResource.PlayerFood = (pResource.PlayerFood - (2*CurrentPeople));
							if (discontent.DiscontentAmmt > 0) {
								discontent.DiscontentAmmt -= .25f;
							}
						} else {
							discontent.DiscontentAmmt += 2;
							pResource.PlayerFood = 0;
						}
					} else {
						discontent.DiscontentAmmt += 2;
					}
					if (!WellAccess) {
						discontent.DiscontentAmmt += 2;
					}
					if (!ChurchAccess) {
						discontent.DiscontentAmmt += 2;
					}
					if (!InnAccess) {
						discontent.DiscontentAmmt += 2;
					}

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
