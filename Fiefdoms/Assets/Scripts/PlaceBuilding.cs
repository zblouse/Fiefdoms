﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour {

	public GameObject HousePrefab;
	public GameObject MillPrefab;
	public GameObject FieldPrefab;
	public GameObject RoadPrefab;
	public GameObject LumberYardPrefab;
	public GameObject QuarryPrefab;
	public GameObject MarketPrefab;

	private GameObject BuildingPrefab;


	public bool placing=false;

	private bool placingRoad = false;
	private bool roadBeginPlaced=false;
	private Vector3 roadBegin;
	private Vector3 roadEnd;
	private Vector3 roadMid;
	private float roadLength;

	private GameObject placingBuilding;
	public GameObject MousePosition;
	public bool collision = false;
	public PlayerResources Resources;
	public RemoveBuilding removeBuilding;
	public PopulationManager PopMan;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (placing) {
			if (!placingRoad) {
				if (Input.GetMouseButtonDown (0) && !collision) {
					if (placingBuilding.transform.tag == "House" && Resources.PlayerWood >= 50) {
						placingBuilding.transform.parent = null;
						placingBuilding.GetComponent<Building> ().BuildingNum = SaveFileControl.control.BuildingCount;
						PopMan.buildings [placingBuilding.GetComponent<Building> ().BuildingNum] = placingBuilding;
						SaveFileControl.control.BuildingCount++;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 0] = placingBuilding.transform.position.x;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 1] = placingBuilding.transform.position.y;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 2] = placingBuilding.transform.position.z;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 3] = 1;

						Resources.PlayerWood = Resources.PlayerWood - 50;
						placingBuilding.GetComponent<House> ().Placed = true;
						ChangeBuilding ();
					}
					if (placingBuilding.transform.tag == "Mill" && Resources.PlayerWood >= 75 && Resources.PlayerStone >= 25) {
						placingBuilding.transform.parent = null;
						placingBuilding.GetComponent<Building> ().BuildingNum = SaveFileControl.control.BuildingCount;
						PopMan.buildings [placingBuilding.GetComponent<Building> ().BuildingNum] = placingBuilding;
						SaveFileControl.control.BuildingCount++;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 0] = placingBuilding.transform.position.x;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 1] = placingBuilding.transform.position.y;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 2] = placingBuilding.transform.position.z;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 3] = 2;
						Resources.PlayerWood = Resources.PlayerWood - 75;
						Resources.PlayerStone = Resources.PlayerStone - 25;
						placingBuilding.GetComponent<Mill> ().placed = true;
						ChangeBuilding ();
					}
					if (placingBuilding.transform.tag == "Field" && Resources.PlayerGold >= 10) {
						placingBuilding.transform.parent = null;
						placingBuilding.GetComponent<Building> ().BuildingNum = SaveFileControl.control.BuildingCount;
						PopMan.buildings [placingBuilding.GetComponent<Building> ().BuildingNum] = placingBuilding;
						SaveFileControl.control.BuildingCount++;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 0] = placingBuilding.transform.position.x;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 1] = placingBuilding.transform.position.y;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 2] = placingBuilding.transform.position.z;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 3] = 3;
						Resources.PlayerGold = Resources.PlayerGold - 10;
						placingBuilding.GetComponent<Field> ().placed = true;
						ChangeBuilding ();
					}
					if (placingBuilding.transform.tag == "LumberYard" && Resources.PlayerWood >= 100) {
						placingBuilding.transform.parent = null;
						placingBuilding.GetComponent<Building> ().BuildingNum = SaveFileControl.control.BuildingCount;
						PopMan.buildings [placingBuilding.GetComponent<Building> ().BuildingNum] = placingBuilding;
						SaveFileControl.control.BuildingCount++;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 0] = placingBuilding.transform.position.x;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 1] = placingBuilding.transform.position.y;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 2] = placingBuilding.transform.position.z;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 3] = 5;
						Resources.PlayerWood = Resources.PlayerWood - 100;
						placingBuilding.GetComponent<LumberYard> ().placed = true;
						ChangeBuilding ();
					}
					if (placingBuilding.transform.tag == "Quarry" && Resources.PlayerStone >= 75 && Resources.PlayerWood>25) {
						placingBuilding.transform.parent = null;
						placingBuilding.GetComponent<Building> ().BuildingNum = SaveFileControl.control.BuildingCount;
						PopMan.buildings [placingBuilding.GetComponent<Building> ().BuildingNum] = placingBuilding;
						SaveFileControl.control.BuildingCount++;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 0] = placingBuilding.transform.position.x;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 1] = placingBuilding.transform.position.y;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 2] = placingBuilding.transform.position.z;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 3] = 6;
						Resources.PlayerWood = Resources.PlayerWood - 25;
						Resources.PlayerStone = Resources.PlayerStone - 75;
						placingBuilding.GetComponent<Quarry> ().placed = true;
						ChangeBuilding ();
					}
					if (placingBuilding.transform.tag == "Market" && Resources.PlayerWood >= 75 && Resources.PlayerStone >= 25) {
						placingBuilding.transform.parent = null;
						placingBuilding.GetComponent<Building> ().BuildingNum = SaveFileControl.control.BuildingCount;
						PopMan.buildings [placingBuilding.GetComponent<Building> ().BuildingNum] = placingBuilding;
						SaveFileControl.control.BuildingCount++;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 0] = placingBuilding.transform.position.x;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 1] = placingBuilding.transform.position.y;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 2] = placingBuilding.transform.position.z;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 3] = 7;
						Resources.PlayerWood = Resources.PlayerWood - 75;
						Resources.PlayerStone = Resources.PlayerStone - 25;
						placingBuilding.GetComponent<Market> ().placed = true;
						ChangeBuilding ();
					}

				} else if (Input.GetMouseButtonDown (0)) {
					Debug.Log ("There is a collision");
				}
				if (Input.GetMouseButtonDown (1)) {
					Destroy (placingBuilding);
					placing = false;
					placingRoad = false;
					collision = false;
				}
			} else {//We are placing a road
				if (Input.GetMouseButtonDown (0) && !collision) {
					if (!roadBeginPlaced) {//starting point of the road
						roadBeginPlaced = true;
						roadBegin = placingBuilding.transform.position;
						placingBuilding.transform.parent = null;
					} else {//ending point of the road
						placingBuilding.transform.parent = null;
						placingBuilding.GetComponent<Building> ().BuildingNum = SaveFileControl.control.BuildingCount;
						PopMan.buildings [placingBuilding.GetComponent<Building> ().BuildingNum] = placingBuilding;
						SaveFileControl.control.BuildingCount++;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 0] = placingBuilding.transform.position.x;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 1] = placingBuilding.transform.position.y;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 2] = placingBuilding.transform.position.z;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 3] = 4;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 4] = roadLength;
						SaveFileControl.control.buildings [SaveFileControl.control.BuildingCount - 1, 5] = placingBuilding.transform.rotation.eulerAngles.y;
						Debug.Log ("YRotation: "+placingBuilding.transform.rotation.eulerAngles.y);
						roadBeginPlaced = false;
						Resources.PlayerStone = (int)(Resources.PlayerStone - 5 * roadLength);
						placingBuilding.GetComponent<Road> ().placed = true;
						ChangeBuilding ();
					}
				} else if (roadBeginPlaced) {//dynamically size road while moving mouse
					
					roadEnd = MousePosition.transform.position;
					roadLength = Vector3.Distance (roadBegin, roadEnd);
					if (roadLength > 0) {
						roadLength = roadLength + .2f;
					} else if (roadLength < 0) {
						roadLength = roadLength - .2f;
					}
					roadMid = (roadBegin + roadEnd) / 2;
					placingBuilding.transform.transform.position = roadMid;
					placingBuilding.transform.LookAt (roadEnd);
					Debug.Log (roadEnd);
					placingBuilding.GetComponent<BoxCollider> ().size = new Vector3 (2, 1, 1 + 1 / roadLength);
					placingBuilding.transform.transform.localScale = new Vector3 (placingBuilding.transform.transform.localScale.x, placingBuilding.transform.transform.localScale.y, roadLength);
				} else if (collision) {
					Debug.Log ("Collision");
				}
				if (Input.GetMouseButtonDown (1)) {
					Destroy (placingBuilding);
					placing = false;
					placingRoad = false;
					roadBeginPlaced = false;
					collision = false;
				}
			}
		}

	}

	public void SelectHouse(){
		removeBuilding.EndRemoving ();
		if (placing) {
			DestroyImmediate (placingBuilding);
		}
		placing = true;
		placingRoad = false;
		BuildingPrefab = HousePrefab;
		ChangeBuilding ();
	}
	public void SelectMill(){
		removeBuilding.EndRemoving ();
		if (placing) {
			DestroyImmediate (placingBuilding);
		}
		placing = true;
		placingRoad = false;
		BuildingPrefab = MillPrefab;
		ChangeBuilding ();
	}
	public void SelectField(){
		removeBuilding.EndRemoving ();
		if (placing) {
			DestroyImmediate (placingBuilding);
		}
		placing = true;
		placingRoad = false;
		BuildingPrefab = FieldPrefab;
		ChangeBuilding ();
	}
	public void SelectRoad(){
		removeBuilding.EndRemoving ();
		if (placing) {
			DestroyImmediate (placingBuilding);
		}
		placing = true;
		placingRoad = true;
		BuildingPrefab = RoadPrefab;
		ChangeBuilding ();
	}
	public void SelectLumberYard(){
		removeBuilding.EndRemoving ();
		if (placing) {
			DestroyImmediate (placingBuilding);
		}
		placing = true;
		placingRoad = false;
		BuildingPrefab = LumberYardPrefab;
		ChangeBuilding ();
	}

	public void SelectQuarry(){
		removeBuilding.EndRemoving ();
		if (placing) {
			DestroyImmediate (placingBuilding);
		}
		placing = true;
		placingRoad = false;
		BuildingPrefab = QuarryPrefab;
		ChangeBuilding ();
	}
	public void SelectMarket(){
		removeBuilding.EndRemoving ();
		if (placing) {
			DestroyImmediate (placingBuilding);
		}
		placing = true;
		placingRoad = false;
		BuildingPrefab = MarketPrefab;
		ChangeBuilding ();
	}

	private void ChangeBuilding(){
		placingBuilding = Instantiate (BuildingPrefab, MousePosition.transform);
		placingBuilding.GetComponentInChildren<PlacingCollision> ().PB=this;
		placingBuilding.transform.localPosition = new Vector3 (0, 0, 0);
	}

	public void EndPlacement(){
		Destroy (placingBuilding);
		placing = false;
		placingRoad = false;
		roadBeginPlaced = false;
		collision = false;
	}

}