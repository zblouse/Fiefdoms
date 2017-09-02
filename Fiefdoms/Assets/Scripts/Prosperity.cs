using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prosperity : MonoBehaviour {

	public float ProsperityAmmt=0;
	public PopulationManager PopMan;
	private bool UnemploymentAdjusted=false;

	void Update(){
		SaveFileControl.control.Prosperity = ProsperityAmmt;
		if (PopMan.Unemployment > .25 && !UnemploymentAdjusted) {
			UnemploymentAdjusted = true;
			ProsperityAmmt = ProsperityAmmt / 5;
		}
		if (PopMan.Unemployment <= .25 && UnemploymentAdjusted) {
			UnemploymentAdjusted = false;
			ProsperityAmmt = ProsperityAmmt * 5;
		}
	}
}
