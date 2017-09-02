
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;// Required when using Event data.

public class BuildingCostPopup : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler// required interface when using the OnPointerEnter method.
{

	Text thisButtonText;
	public Text BuildingCostText;


	void Start(){
		thisButtonText = gameObject.GetComponentInChildren<Text> ();
	}
	//Do this when the cursor enters the rect area of this selectable UI object.
	public void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("The cursor entered the selectable UI element. "+thisButtonText.text);
		if (thisButtonText.text == "House") {
			BuildingCostText.text = "Building Cost\n50 Wood";
		}else if (thisButtonText.text == "Mill") {
			BuildingCostText.text = "Building Cost\n75 Wood 25 Stone";
		}else if (thisButtonText.text == "Field") {
			BuildingCostText.text = "Building Cost\n10 Gold";
		}else if (thisButtonText.text == "Road") {
			BuildingCostText.text = "Building Cost\n5 Stone per Length";
		}else if (thisButtonText.text == "Lumber\nYard") {
			BuildingCostText.text = "Building Cost\n100 Wood";
		}else if (thisButtonText.text == "Quarry") {
			BuildingCostText.text = "Building Cost\n25 Wood 75 Stone";
		}else if (thisButtonText.text == "Inn") {
			BuildingCostText.text = "Building Cost\n50 Wood 50 Stone";
		}else if (thisButtonText.text == "Church") {
			BuildingCostText.text = "Building Cost\n50 Wood 50 Stone";
		}else if (thisButtonText.text == "Market") {
			BuildingCostText.text = "Building Cost\n75 Wood 25 Stone";
		}else if (thisButtonText.text == "Trade\nDepo") {
			BuildingCostText.text = "Building Cost\n50 Wood 50 Stone";
		}else if (thisButtonText.text == "Well") {
			BuildingCostText.text = "Building Cost\n50 Stone";
		}
	}
	public void OnPointerExit(PointerEventData eventData){
		BuildingCostText.text = "";
	}
}