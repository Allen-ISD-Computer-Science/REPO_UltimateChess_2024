using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerritoryManager : MonoBehaviour
{

	public static TerritoryManager instance;
	
	public List<GameObject> territoryList = new List<GameObject>();

	void Awake()
	{
		instance = this;
	}

   	// Start is called before the first frame update
   	void Start()
   	{
        	AddTerritoryData();

			TintTerritories();

  	}
	
	void AddTerritoryData()
	{
		GameObject[] theArray = GameObject.FindGameObjectsWithTag("Territory") as GameObject[];
		foreach(GameObject territory in theArray)
		{
			territoryList.Add(territory);
		}

		TintTerritories();
	}

	public void TintTerritories()
	{
		for(int i = 0;i<territoryList.Count; i++)
		{
			TerritoryHandler countHandler = territoryList[i].GetComponent<TerritoryHandler>();

			if(countHandler.territory.player == Territory.Players.Player1)
			{
				countHandler.TintColor(new Color32(165,234,202,255));
			}

			if(countHandler.territory.player == Territory.Players.Player2)
			{
				countHandler.TintColor(new Color32(220,176,192,255));
			}

			if(countHandler.territory.player == Territory.Players.Player3)
			{
				countHandler.TintColor(new Color32(229,172,74,255));
			}

			if(countHandler.territory.player == Territory.Players.Player4)
			{
				countHandler.TintColor(new Color32(209,124,124,255));
			}
			
			if(countHandler.territory.player == Territory.Players.Player5)
			{
				countHandler.TintColor(new Color32(91,136,214,255));
			}

			if(countHandler.territory.player == Territory.Players.Player6)
			{
				countHandler.TintColor(new Color32(108,208,90,255));
			}
		}
	}
}