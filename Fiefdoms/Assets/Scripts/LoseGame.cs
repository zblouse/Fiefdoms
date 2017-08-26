using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseGame : MonoBehaviour {
	public LiegeRequests Liege;
	public GameObject GameOverPanel;
	public PauseGame pause;
	public Discontent discontent;
	public Text LoseText;
	// Use this for initialization
	void Start () {
		GameOverPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Liege.LiegeOpinion <= 0) {//lose Game
			pause.GamePaused=true;
			GameOverPanel.SetActive(true);
		}
		if (discontent.DiscontentAmmt > 100) {
			pause.GamePaused = true;
			LoseText.text = "Your people grew so disgruntled your liege decided to step in and replace you with someone hopefully more competent.";
			GameOverPanel.SetActive(true);
		}
	}
}
