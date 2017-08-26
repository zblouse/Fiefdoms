using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discontent : MonoBehaviour {
	public float DiscontentAmmt;
	public ElapsedTime eTime;
	public PopulationManager PopMan;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (eTime.NewMonth) {
			if (PopMan.Unemployment > .15) {
				DiscontentAmmt += 3;
			} else if(DiscontentAmmt>0){
				DiscontentAmmt -= .5f;
			}
		}
		SaveFileControl.control.Discontent = DiscontentAmmt;
	}
}
