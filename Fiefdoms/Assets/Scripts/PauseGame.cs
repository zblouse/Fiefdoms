using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseGame : MonoBehaviour {

	public bool GamePaused=false;
	public Text PauseText;
	void Start(){
		PauseText.enabled = false;
	}
	public void Pause(){
		
		GamePaused = !GamePaused;
		if (GamePaused) {
			PauseText.enabled = true;
		} else {
			PauseText.enabled = false;
		}
	}
}
