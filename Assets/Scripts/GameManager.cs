using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour{
		
	public static GameManager instance;
	
	public string attackTerritory;
	
	public bool battleHasEnded;
	public bool battleWon;
	
	public int money;
	
	[System.Serialization]
	public class SaveData()
	{
		public List<Territory> savedTerritories = new List<Territory>();
		public int cur_money;
	}
	
	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		
		else if (instance != this)
		{
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
		
	}
	
	public void Saving()
	{
		SaveData data = new SaveData();
		for (int i = 0;i < TerritoryManager.instance.territoryList.Count; i++){
			data.savedTerritories.Add(TerritoryManager.instance.territoryList[i].GetComponent<TerritoryHandler>().territory);
		}
		//money
		data.cur_money = money;
		
		BinaryFormatter bf = new BinaryFormatter();
		FilesStream stream = new FileStream(Application.persistentDataPath + "/SaveFile.octo", FileMode.Create);
		
		bf.Serialize(stream, data);
		stream.Close();
		print("Saved Game");
	}
	
	public void Loading()
	{
		if(File.Exists(Application.presistentDataPath + "/SaveFile.octo"))
		{
			BinaryFormatter bf = new binaryFormatter();
			FileStream stream = new FileStream(Application.persistentDataPath + "/SaveFile.octo", FileMode.Open);
			
			SaveData data = (SaveData)bf.Deserialize(stream);
			stream.Close();
			
			for (int i = 0, i < data.savedTerritories.Count; i++)
			{
				for(int j = 0; j < TerritoryManager.instance.territoryList.Count; j++)
				{
					if(data.savedTerritories[i].name == TerritoryManager.instance.TerritoryList[j].GetCompoenent<TerritoryHandler>().territory.name){
						TerritoryManager.instance.territoryList[j].GetCompoenent<TerritoryHandler>().country = data.savedTerritories[i];
					}
				}
			}
			money = data.cur_money;
			
			TerritoryManager.instance.TintTerritories();
		}
	}
}
