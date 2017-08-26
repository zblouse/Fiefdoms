using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour {
	public PauseGame pause;
	bool menuOpen = false;
	public GameObject MenuPanel;
	// Use this for initialization
	void Start () {
		MenuPanel.SetActive (false);
	}
	


	public void Menu(){
		menuOpen = !menuOpen;
		MenuPanel.SetActive (menuOpen);
		if (!pause.GamePaused) {
			pause.Pause ();
		}

	}

	public void QuitGame(){
		Application.Quit ();
	}
	public void MainMenu(){
		SceneManager.LoadScene (0);
	}
	public void LoadScene(int scene){
		SceneManager.LoadScene (0);
	}
	public void ResumeGame(){
		menuOpen = !menuOpen;
		MenuPanel.SetActive (menuOpen);
		pause.Pause ();
	}
}
