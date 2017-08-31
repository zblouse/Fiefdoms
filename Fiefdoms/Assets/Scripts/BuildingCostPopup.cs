
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
			BuildingCostText.text = "50 Wood";
		}else if (thisButtonText.text == "Mill") {
			BuildingCostText.text = "75 Wood 25 Stone";
		}else if (thisButtonText.text == "Field") {
			BuildingCostText.text = "10 Gold";
		}else if (thisButtonText.text == "Road") {
			BuildingCostText.text = "5 Stone per Length";
		}else if (thisButtonText.text == "Lumber\nYard") {
			BuildingCostText.text = "100 Wood";
		}else if (thisButtonText.text == "Quarry") {
			BuildingCostText.text = "25 Wood 75 Stone";
		}else if (thisButtonText.text == "Inn") {
			BuildingCostText.text = "50 Wood 50 Stone";
		}else if (thisButtonText.text == "Church") {
			BuildingCostText.text = "50 Wood 50 Stone";
		}else if (thisButtonText.text == "Market") {
			BuildingCostText.text = "75 Wood 25 Stone";
		}else if (thisButtonText.text == "Trade\nDepo") {
			BuildingCostText.text = "50 Wood 50 Stone";
		}else if (thisButtonText.text == "Well") {
			BuildingCostText.text = "50 Stone";
		}
	}
	public void OnPointerExit(PointerEventData eventData){
		BuildingCostText.text = "";
	}
}