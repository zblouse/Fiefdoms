using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerResources : MonoBehaviour {
	public int PlayerGold;
	public int PlayerFood;
	public int PlayerWood;
	public int PlayerStone;
	public int PlayerPop;

	public Text PlayerText;

	public PopulationManager PopManager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPop = PopManager.PlayerPopulation;
		PlayerText.text = "Gold: " + PlayerGold + " Population: " + PlayerPop+ " Food: " +PlayerFood+" Wood: "+PlayerWood+ " Stone: "+PlayerStone;

		SaveFileControl.control.PlayerGold = PlayerGold;
		SaveFileControl.control.PlayerPop = PlayerPop;
		SaveFileControl.control.PlayerFood = PlayerFood;
		SaveFileControl.control.PlayerWood = PlayerWood;
		SaveFileControl.control.PlayerStone = PlayerStone;
	}
}
