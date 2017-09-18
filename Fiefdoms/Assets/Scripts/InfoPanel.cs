using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour {
	public GameObject Panel;
	public PauseGame pause;
	public PopulationManager popMan;
	public VictoryConditions victory;
	public LiegeRequests Liege;
	private string liegeRequestString;
	public ElapsedTime eTime;
	public Text InfoText;
	public Discontent discontent;
	public Prosperity prosp;


	// Use this for initialization
	void Start () {
		Panel.SetActive (false);

	}
	public void ShowPanel(){
		Panel.SetActive (true);
		InfoText.text = "Click one of the above buttons to see more information about your fiefdom";
		pause.Pause ();
	}
	public void HidePanel(){
		Panel.SetActive (false);
		pause.Pause ();
	}
	public void ShowEmploymentInfo(){
		InfoText.text = "Employed: "+popMan.EmployedPeople+"\nUnemployed: "+(popMan.PlayerPopulation-popMan.EmployedPeople)+"\nUnemployment Rate: "+(int)((popMan.Unemployment)*100)+"%";
	}
	public void ShowVictoryConditions(){
		InfoText.text="Required Population: "+victory.PopulationReq+"\t\tCurrent Population: "+popMan.PlayerPopulation+"\nMaximum Discontent: "+victory.DiscontentReq+"\t\tCurrent Discontent: "+discontent.DiscontentAmmt;
	}
	public void ShowLiegeInfo(){
		if (eTime.currentMonth >= 5 && eTime.currentMonth <= 11) {
			liegeRequestString = "Current Request: ";
			if (Liege.requestedResource == 1) {//gold
				liegeRequestString = liegeRequestString + "50 gold";
			} else if (Liege.requestedResource == 2) {//food
				liegeRequestString = liegeRequestString + "150 food";
			} else if (Liege.requestedResource == 3) {//wood
				liegeRequestString = liegeRequestString + "100 wood";
			} else if (Liege.requestedResource == 4) {//food
				liegeRequestString = liegeRequestString + "100 stone";
			}
			if (Liege.requestFulfilled) {
				liegeRequestString = liegeRequestString + "\nStatus: Sent";
			} else {
				liegeRequestString = liegeRequestString + "\nStatus: Not Sent";
			}
		} else {
			liegeRequestString="No Current Request";
		}
		InfoText.text="Liege Opinion: "+Liege.LiegeOpinion+"\n"+liegeRequestString;
	}
	public void ShowDiscontent(){
		InfoText.text="Discontent: "+(int)discontent.DiscontentAmmt;
	}
	public void ShowProsperity(){
		InfoText.text="Prosperity: "+(int)prosp.ProsperityAmmt;
	}


}
