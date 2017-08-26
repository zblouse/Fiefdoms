using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ElapsedTime : MonoBehaviour {
	public int currentMonth;
	public bool NewMonth=true;//only true for the first frame of the new month
	public int currentYear;
	public float speed = 10f;
	public float timeSinceLastMonth=0;
	private string month;
	public Text DateText;
	public PauseGame pause;
	// Use this for initialization
	void Start () {
		currentMonth = SaveFileControl.control.CurrentMonth;
		currentYear = SaveFileControl.control.CurrentYear;
	}
	
	// Update is called once per frame
	void Update () {
		if (!pause.GamePaused) {
			NewMonth = false;
			timeSinceLastMonth = timeSinceLastMonth + Time.deltaTime;
			if (timeSinceLastMonth >= 60f / speed) {
				NewMonth = true;
				currentMonth++;
				timeSinceLastMonth = 0;
				if (currentMonth == 13) {
					currentYear++;
					currentMonth = 1;
				}
			}
			if (currentMonth == 1) {
				month = "January";
			} else if (currentMonth == 2) {
				month = "February";
			} else if (currentMonth == 3) {
				month = "March";
			} else if (currentMonth == 4) {
				month = "April";
			} else if (currentMonth == 5) {
				month = "May";
			} else if (currentMonth == 6) {
				month = "June";
			} else if (currentMonth == 7) {
				month = "July";
			} else if (currentMonth == 8) {
				month = "August";
			} else if (currentMonth == 9) {
				month = "September";
			} else if (currentMonth == 10) {
				month = "October";
			} else if (currentMonth == 11) {
				month = "November";
			} else if (currentMonth == 12) {
				month = "December";
			}
			DateText.text = month + " " + currentYear;
		}
		SaveFileControl.control.CurrentMonth = currentMonth;
		SaveFileControl.control.CurrentYear = currentYear;


	}
}
