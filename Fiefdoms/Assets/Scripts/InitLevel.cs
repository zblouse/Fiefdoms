using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InitLevel : MonoBehaviour {

	public GameObject HousePrefab;
	public GameObject House2Prefab;
	public GameObject House3Prefab;
	public GameObject MillPrefab;
	public GameObject FieldPrefab;
	public GameObject RoadPrefab;
	public GameObject LumberYardPrefab;
	public GameObject QuarryPrefab;
	public GameObject MarketPrefab;
	public GameObject TradeDepoPrefab;
	public GameObject WellPrefab;
	public GameObject InnPrefab;
	public GameObject ChurchPrefab;

	private GameObject newBuilding;
	public PlayerResources resources;
	public PopulationManager PopManager;
	public LiegeRequests requests;
	public PlaceBuilding place;
	public Prosperity prosp;
	public PlaceBuilding PB;
	void Awake(){
		resources.PlayerFood = SaveFileControl.control.PlayerFood;
		resources.PlayerGold = SaveFileControl.control.PlayerGold;
		resources.PlayerPop = SaveFileControl.control.PlayerPop;
		resources.PlayerStone = SaveFileControl.control.PlayerStone;
		resources.PlayerWood = SaveFileControl.control.PlayerWood;

		requests.requestFulfilled = SaveFileControl.control.RequestFulfilled;
		requests.requestedResource = SaveFileControl.control.RequestedResource;
		requests.LiegeOpinion = SaveFileControl.control.LiegeOpinion;

		prosp.ProsperityAmmt = SaveFileControl.control.Prosperity;

		PopManager.EmployedPeople = SaveFileControl.control.TotalEmployees;

		Debug.Log (SaveFileControl.control.BuildingCount);
		for(int i=0;i<SaveFileControl.control.BuildingCount;i++){
			//Debug.Log (SaveFileControl.control.buildings [i, 3]);
			if (SaveFileControl.control.buildings [i, 3] == 1f) {//House
				Debug.Log("House Level: "+ SaveFileControl.control.buildings [i, 5]);
				if (SaveFileControl.control.buildings [i, 5] == 1) {
					Debug.Log("House1");
					newBuilding = Instantiate (HousePrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), HousePrefab.transform.rotation, null);
				}else if(SaveFileControl.control.buildings [i, 5] == 2){
					newBuilding = Instantiate (House2Prefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), House2Prefab.transform.rotation, null);
				}else if(SaveFileControl.control.buildings [i, 5] == 3){
					newBuilding = Instantiate (House3Prefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), House3Prefab.transform.rotation, null);
				}
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponent<House> ().CurrentPeople = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<House> ().HouseLevel = (int)SaveFileControl.control.buildings [i, 5];
				newBuilding.GetComponent<House> ().Placed = true;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.PlayerPopulation+=(int)SaveFileControl.control.buildings [i, 4];
				PopManager.buildings [i] = newBuilding;
				Debug.Log (new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]));
			}
			if (SaveFileControl.control.buildings [i, 3] == 2f) {//Mill

				newBuilding=Instantiate (MillPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), MillPrefab.transform.rotation, null);
				newBuilding.GetComponent<Mill> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<Mill> ().placed = true;
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;
				Debug.Log (new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]));
			}
			if (SaveFileControl.control.buildings [i, 3] == 3f) {//Field
				newBuilding=Instantiate (FieldPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), FieldPrefab.transform.rotation, null);
				newBuilding.GetComponent<Field>().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				Debug.Log ((int)SaveFileControl.control.buildings [i, 4]);
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				PopManager.buildings [i] = newBuilding;
				newBuilding.GetComponent<Field> ().placed = true;
			
			}
			if (SaveFileControl.control.buildings [i, 3] == 4f) {//Road
				newBuilding=Instantiate (RoadPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), RoadPrefab.transform.rotation, null);
				newBuilding.GetComponent<Road> ().placed = true;
				newBuilding.GetComponent<BoxCollider> ().size = new Vector3 (2, 1, 1 + 1 / SaveFileControl.control.buildings [i, 4]);
				newBuilding.transform.transform.localScale = new Vector3 (newBuilding.transform.transform.localScale.x, newBuilding.transform.transform.localScale.y, SaveFileControl.control.buildings [i, 4]);
				newBuilding.transform.RotateAround (newBuilding.transform.position,Vector3.up,SaveFileControl.control.buildings [i, 5]);
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;
				Debug.Log ("Y rotation: " + SaveFileControl.control.buildings [i, 5]);

			}
			if (SaveFileControl.control.buildings [i, 3] == 5f) {//LumberYard
				newBuilding=Instantiate (LumberYardPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), LumberYardPrefab.transform.rotation, null);
				newBuilding.GetComponent<LumberYard> ().placed = true;
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				newBuilding.GetComponent<LumberYard> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				PopManager.buildings [i] = newBuilding;

			}
			if (SaveFileControl.control.buildings [i, 3] == 6f) {//Quarry
				newBuilding=Instantiate (QuarryPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), QuarryPrefab.transform.rotation, null);
				newBuilding.GetComponent<Quarry> ().placed = true;
				newBuilding.GetComponent<Quarry> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;

			}
			if (SaveFileControl.control.buildings [i, 3] == 7f) {//Market
				place.MarketCount++;
				newBuilding=Instantiate (MarketPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), MarketPrefab.transform.rotation, null);
				newBuilding.GetComponent<Market> ().placed = true;
				newBuilding.GetComponent<Market> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;

			}
			if (SaveFileControl.control.buildings [i, 3] == 8f) {//TradeDepo
				newBuilding=Instantiate (TradeDepoPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), TradeDepoPrefab.transform.rotation, null);
				newBuilding.GetComponent<TradeDepo> ().placed = true;
				newBuilding.GetComponent<TradeDepo> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;

			}
			if (SaveFileControl.control.buildings [i, 3] == 9f) {//Well
				newBuilding=Instantiate (WellPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), WellPrefab.transform.rotation, null);
				newBuilding.GetComponent<Well> ().placed = true;
				newBuilding.GetComponent<Well> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;

			}
			if (SaveFileControl.control.buildings [i, 3] == 10f) {//Well
				newBuilding=Instantiate (InnPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), InnPrefab.transform.rotation, null);
				newBuilding.GetComponent<Inn> ().placed = true;
				newBuilding.GetComponent<Inn> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;

			}
			if (SaveFileControl.control.buildings [i, 3] == 11f) {//Church
				newBuilding=Instantiate (ChurchPrefab, new Vector3 (SaveFileControl.control.buildings [i, 0], SaveFileControl.control.buildings [i, 1], SaveFileControl.control.buildings [i, 2]), ChurchPrefab.transform.rotation, null);
				newBuilding.GetComponent<Church> ().placed = true;
				newBuilding.GetComponent<Church> ().CurrentEmployees = (int)SaveFileControl.control.buildings [i, 4];
				newBuilding.GetComponent<Building> ().BuildingNum = i;
				newBuilding.GetComponentInChildren<PlacingCollision> ().PB = PB;
				PopManager.buildings [i] = newBuilding;

			}
		}



		Debug.Log ("I initialized");
	}


}
