using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradePanel : MonoBehaviour {
	public GameObject panel;

	public int ResourceGoing;//1 gold, 2 food, 3 wood, 4 stone
	public int ResourceComing;//1 gold, 2 food, 3 wood, 4 stone
	public int Ammount=0;

	public int foodSellPrice=1;
	public int woodSellPrice=3;
	public int stoneSellPrice = 3;

	public int foodBuyPrice=3;
	public int woodBuyPrice=5;
	public int stoneBuyPrice=5;

	public PlayerResources resources;
	public PauseGame pause;

	public Text ConfirmText;

	public Text FoodSellPriceLabel;
	public Text WoodSellPriceLabel;
	public Text StoneSellPriceLabel;

	public Text FoodBuyPriceLabel;
	public Text WoodBuyPriceLabel;
	public Text StoneBuyPriceLabel;

	public InputField AmmountInput;
	// Use this for initialization
	void Start () {
		panel.SetActive (false);
		FoodSellPriceLabel.text = "" + foodSellPrice;
		WoodSellPriceLabel.text = "" + woodSellPrice;
		StoneSellPriceLabel.text = "" + stoneSellPrice;

		FoodBuyPriceLabel.text = "" + foodBuyPrice;
		WoodBuyPriceLabel.text = "" + woodBuyPrice;
		StoneBuyPriceLabel.text = "" + stoneBuyPrice;
	}


	public void ShowDialog(){
		panel.SetActive (true);
		pause.GamePaused=true;
	}
	public void HideDialog(){
		panel.SetActive (false);
		pause.GamePaused = false;
	}
	public void Exchange(){
		SetAmmount ();
		if (ResourceComing == 1) {//trading away for gold
			if (ResourceGoing == 2) {//giving food
				resources.PlayerFood = resources.PlayerFood - Ammount;
				resources.PlayerGold = resources.PlayerGold + Ammount * foodSellPrice;
			} else if (ResourceGoing == 3) {//giving wood
				resources.PlayerWood = resources.PlayerWood - Ammount;
				resources.PlayerGold = resources.PlayerGold + Ammount * woodSellPrice;
			} else if (ResourceGoing == 4) {//giving stone
				resources.PlayerStone = resources.PlayerStone - Ammount;
				resources.PlayerGold = resources.PlayerGold + Ammount * stoneSellPrice;
			}
		} else if (ResourceComing == 2) {//getting food
			resources.PlayerFood+=Ammount;
			resources.PlayerGold -= Ammount * foodBuyPrice;
		}else if (ResourceComing == 3) {//getting wood
			resources.PlayerWood+=Ammount;
			resources.PlayerGold -= Ammount * woodBuyPrice;
		}else if (ResourceComing == 4) {//getting stone
			resources.PlayerStone += Ammount;
			resources.PlayerGold -= Ammount * stoneBuyPrice;
		}
	}

	public void SetFoodBuy(){
		SetAmmount ();
		ResourceComing = 2;
		ResourceGoing = 1;
		ConfirmText.text = "Buying " + Ammount + " food for " + (Ammount * foodBuyPrice)+" gold";
	}
	public void SetWoodBuy(){
		SetAmmount ();
		ResourceComing = 3;
		ResourceGoing = 1;
		ConfirmText.text = "Buying " + Ammount + " wood for " + (Ammount * woodBuyPrice)+" gold";
	}
	public void SetStoneBuy(){
		SetAmmount ();
		ResourceComing = 4;
		ResourceGoing = 1;
		ConfirmText.text = "Buying " + Ammount + " stone for " + (Ammount * stoneBuyPrice)+" gold";
	}
	public void SetFoodSell(){
		SetAmmount ();
		ResourceComing = 1;
		ResourceGoing = 2;
		ConfirmText.text = "Selling " + Ammount + " food for " + (Ammount * foodSellPrice)+" gold";
	}
	public void SetWoodSell(){
		SetAmmount ();
		ResourceComing = 1;
		ResourceGoing = 3;
		ConfirmText.text = "Selling " + Ammount + " wood for " + (Ammount * woodSellPrice)+" gold";
	}
	public void SetStoneSell(){
		SetAmmount ();
		ResourceComing = 1;
		ResourceGoing = 4;
		ConfirmText.text = "Selling " + Ammount + " stone for " + (Ammount * stoneSellPrice)+" gold";
	}
	public void SetAmmount(){
		Ammount = int.Parse(AmmountInput.text);

		if (ResourceComing == 1) {//trading away for gold
			if (ResourceGoing == 2) {//giving food
				ConfirmText.text = "Buying " + Ammount + " food for " + (Ammount * foodBuyPrice)+" gold";
			} else if (ResourceGoing == 3) {//giving wood
				ConfirmText.text = "Buying " + Ammount + " wood for " + (Ammount * woodBuyPrice)+" gold";
			} else if (ResourceGoing == 4) {//giving stone
				ConfirmText.text = "Buying " + Ammount + " stone for " + (Ammount * stoneBuyPrice)+" gold";
			}
		} else if (ResourceComing == 2) {//getting food
			ConfirmText.text = "Selling " + Ammount + " food for " + (Ammount * foodSellPrice)+" gold";
		}else if (ResourceComing == 3) {//getting wood
			ConfirmText.text = "Selling " + Ammount + " wood for " + (Ammount * woodSellPrice)+" gold";
		}else if (ResourceComing == 4) {//getting stone
			ConfirmText.text = "Selling " + Ammount + " stone for " + (Ammount * stoneSellPrice)+" gold";
		}
	}



}
