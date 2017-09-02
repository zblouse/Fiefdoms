using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class SaveFileControl : MonoBehaviour {

	public static SaveFileControl control;

	public int PlayerGold;
	public int PlayerWood;
	public int PlayerFood;
	public int PlayerPop;
	public int PlayerStone;

	public int TotalEmployees;

	public int CurrentYear;
	public int CurrentMonth;

	public float Discontent;
	public float Prosperity;

	public bool RequestFulfilled;
	public int RequestedResource;
	public int LiegeOpinion;

	public int BuildingCount;
	public float[,] buildings;


	// Use this for initialization
	void Awake () {

		if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
			if (File.Exists (Application.persistentDataPath + "/playerDat.dat")) {
				load ();

			} else {
				PlayerGold = 50;
				PlayerWood = 500;
				PlayerStone = 500;
				PlayerPop = 0;
				PlayerFood = 500;
				BuildingCount = 0;
				buildings=new float[500,6];
				CurrentYear = 875;
				CurrentMonth = 1;
				TotalEmployees = 0;
				RequestedResource = 0;
				LiegeOpinion = 50;
				RequestFulfilled = false;
				Discontent = 0;
				Prosperity = 0;
			}

		} else if (control != this) {
			Destroy (gameObject);
		}

	}
	void OnDestroy(){
		save ();
	}

	public void save(){

		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath+ "/playerDat.dat");
		PlayerData data = new PlayerData ();
		data.PlayerGold = control.PlayerGold;
		data.PlayerFood = control.PlayerFood;
		data.PlayerPop = control.PlayerPop;
		data.PlayerWood = control.PlayerWood;
		data.PlayerStone = control.PlayerStone;
		data.BuildingCount = control.BuildingCount;
		data.CurrentYear = control.CurrentYear;
		data.CurrentMonth = control.CurrentMonth;
		data.buildings = control.buildings;
		data.TotalEmployees = control.TotalEmployees;
		data.RequestFulfilled = control.RequestFulfilled;
		data.RequestedResource = control.RequestedResource;
		data.LiegeOpinion = control.LiegeOpinion;
		data.Discontent = control.Discontent;
		data.Prosperity = control.Prosperity;

		bf.Serialize (file, data);
		file.Close();

	}

	public void load(){
		if (File.Exists (Application.persistentDataPath + "/playerDat.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath+ "/playerDat.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();
			control.PlayerGold = data.PlayerGold;
			control.PlayerFood = data.PlayerFood;
			control.PlayerPop = data.PlayerPop;
			control.PlayerStone = data.PlayerStone;
			control.PlayerWood = data.PlayerWood;
			control.BuildingCount = data.BuildingCount;
			control.CurrentYear = data.CurrentYear;
			control.CurrentMonth = data.CurrentMonth;
			control.buildings = data.buildings;
			control.TotalEmployees = data.TotalEmployees;
			control.RequestedResource = data.RequestedResource;
			control.RequestFulfilled = data.RequestFulfilled;
			control.LiegeOpinion = data.LiegeOpinion;
			control.Discontent = data.Discontent;
			control.Prosperity = data.Prosperity;
		}
	}
	public void NewSaveFile(){
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create (Application.persistentDataPath+ "/playerDat.dat");
		PlayerData data = new PlayerData ();
		data.PlayerFood = 500;
		data.PlayerGold = 50;
		data.PlayerPop = 0;
		data.PlayerWood = 500;
		data.PlayerStone = 500;
		data.BuildingCount = 0;
		data.CurrentYear = 875;
		data.CurrentMonth = 1;
		data.buildings=new float[500,6];
		data.TotalEmployees = 0;
		data.RequestedResource = 0;
		data.RequestFulfilled = false;
		data.LiegeOpinion = 50;
		data.Discontent = 0;
		data.Prosperity = 0;

		control.PlayerFood = 500;
		control.PlayerGold = 50;
		control.PlayerPop = 0;
		control.PlayerWood = 500;
		control.PlayerStone = 500;
		control.BuildingCount = 0;
		control.CurrentYear = 875;
		control.CurrentMonth = 1;
		control.buildings=new float[500,6];
		control.TotalEmployees = 0;
		control.RequestedResource = 0;
		control.RequestFulfilled = false;
		control.LiegeOpinion = 50;
		control.Discontent = 0;
		control.Prosperity = 0;

		bf.Serialize (file, data);
		file.Close();
		SceneManager.LoadScene (1);
	}
	public void LoadScene(int scene){
		SceneManager.LoadScene (scene);
	}
}
[Serializable]
class PlayerData{
	public int PlayerGold;
	public int PlayerWood;
	public int PlayerFood;
	public int PlayerPop;
	public int PlayerStone;

	public int TotalEmployees;

	public int CurrentYear;
	public int CurrentMonth;

	public float Discontent;
	public float Prosperity;

	public bool RequestFulfilled;
	public int RequestedResource;
	public int LiegeOpinion;

	public int BuildingCount;
	public float[,] buildings;

}

