using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LiegeRequests : MonoBehaviour {
	public ElapsedTime eTime;
	public PlayerResources resources;
	public PauseGame pause;
	public PlaceBuilding PB;
	public GameObject RequestPanel;
	public GameObject FulfilledPanel;
	public GameObject DeniedPanel;
	public Text FulfilledText;
	public Text RequestText;
	public Button SendNowButton;
	public bool requestFulfilled = false;
	public int requestedResource;//1 = gold, 2 = food, 3 = wood, 4 = stone

	public int LiegeOpinion;

	bool newMonthNextDay;

	// Use this for initialization
	void Start () {
		RequestPanel.SetActive (false);
		FulfilledPanel.SetActive (false);
		DeniedPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		

		if (eTime.currentMonth == 5 && newMonthNextDay) {//Generate the request, tell the player
			newMonthNextDay=false;
			RequestPanel.SetActive (true);

			pause.Pause ();
			Debug.Log (pause.GamePaused);
			requestFulfilled=false;
			SaveFileControl.control.RequestFulfilled = requestFulfilled;
			requestedResource = Random.Range (1, 5);
			SaveFileControl.control.RequestedResource = requestedResource;
			if (requestedResource == 1) {//gold
				RequestText.text = "This year I would like your harvest payment in the form of 50 Gold. As always I'll expect it in November.";
				if (resources.PlayerGold >= 50) {
					SendNowButton.enabled = true;
				} else {
					SendNowButton.enabled = false;
				}
			} else if (requestedResource == 2) {//food
				RequestText.text = "This year I would like your harvest payment in the form of 150 Food. As always I'll expect it in November.";
				if (resources.PlayerFood >= 150) {
					SendNowButton.enabled = true;
				} else {
					SendNowButton.enabled = false;
				}
			} else if (requestedResource == 3) {//wood
				RequestText.text = "This year I would like your harvest payment in the form of 100 Wood. As always I'll expect it in November.";
				if (resources.PlayerWood >= 100) {
					SendNowButton.enabled = true;
				} else {
					SendNowButton.enabled = false;
				}
			} else if (requestedResource == 4) {//stone
				RequestText.text = "This year I would like your harvest payment in the form of 100 Stone. As always I'll expect it in November.";
				if (resources.PlayerStone >= 100) {
					SendNowButton.enabled = true;
				} else {
					SendNowButton.enabled = false;
				}
			}
			PB.EndPlacement ();
		}
		if (eTime.currentMonth == 12 && newMonthNextDay && !requestFulfilled) {
			newMonthNextDay = false;
			LiegeOpinion = LiegeOpinion - 15;
			SaveFileControl.control.LiegeOpinion = LiegeOpinion;
			DeniedPanel.SetActive (true);
			pause.Pause ();
		}
		if (eTime.currentMonth == 11 && newMonthNextDay) {
			newMonthNextDay=false;
			if (requestFulfilled) {
				FulfilledPanel.SetActive (true);
				pause.Pause();
				FulfilledText.text="Thank you for your shipment.";
				PB.EndPlacement ();
			} else {
				RequestPanel.SetActive (true);

				pause.Pause();
				if (requestedResource == 1) {//gold
					RequestText.text = "It is time for your harvest payment of 50 Gold";
					if (resources.PlayerGold >= 50) {
						SendNowButton.enabled = true;
					} else {
						SendNowButton.enabled = false;
					}
				} else if (requestedResource == 2) {//food
					RequestText.text = "It is time for your harvest payment of 150 Food";
					if (resources.PlayerFood >= 150) {
						SendNowButton.enabled = true;
					} else {
						SendNowButton.enabled = false;
					}
				} else if (requestedResource == 3) {//wood
					RequestText.text = "It is time for your harvest payment of 100 Wood";
					if (resources.PlayerWood >= 100) {
						SendNowButton.enabled = true;
					} else {
						SendNowButton.enabled = false;
					}
				} else if (requestedResource == 4) {//stone
					RequestText.text = "It is time for your harvest payment of 100 Stone.";
					if (resources.PlayerStone >= 100) {
						SendNowButton.enabled = true;
					} else {
						SendNowButton.enabled = false;
					}
				}
				PB.EndPlacement ();
			}
		}
		if (eTime.NewMonth) {
			newMonthNextDay = true;
		} else {
			newMonthNextDay = false;
		}
	}

	public void DismissRequest(){
		pause.Pause ();
		RequestPanel.SetActive (false);
		if (eTime.currentMonth == 11) {
			Debug.Log ("Failed to FUlfill Request");
		}
	}
	public void DismissFulfilled(){
		pause.Pause ();
		FulfilledPanel.SetActive (false);
	}
	public void DismissDenied(){
		pause.Pause ();
		DeniedPanel.SetActive (false);
	}
	public void FulfillRequest(){
		pause.Pause ();
		requestFulfilled = true;
		LiegeOpinion += 5;
		SaveFileControl.control.RequestFulfilled = requestFulfilled;
		if (requestedResource == 1) {//gold
			resources.PlayerGold = resources.PlayerGold-50;
		} else if (requestedResource == 2) {//food
			resources.PlayerFood = resources.PlayerFood - 150;
		} else if (requestedResource == 3) {//wood
			resources.PlayerWood=resources.PlayerWood-100;
		} else if (requestedResource == 4) {//stone
			resources.PlayerStone=resources.PlayerStone-100;
		}
		RequestPanel.SetActive (false);
	}
}
