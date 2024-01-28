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

	void TintTerritories()
	{
		for(int i = 0;i<territoryList.Count; i++)
		{
			TerritoryHandler countHandler = territoryList[i].GetComponent<TerritoryHandler>();

			if(countHandler.territory.region == Territory.Regions.Oceania)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}

			if(countHandler.territory.region == Territory.Regions.Asia)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}

			if(countHandler.territory.region == Territory.Regions.EastEurope)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}

			if(countHandler.territory.region == Territory.Regions.WestEurope)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}

			if(countHandler.territory.region == Territory.Regions.Canada)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}
			
			if(countHandler.territory.region == Territory.Regions.UnitedStates)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}

			if(countHandler.territory.region == Territory.Regions.SouthAmerica)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}

			if(countHandler.territory.region == Territory.Regions.NorthAfrica)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}

			if(countHandler.territory.region == Territory.Regions.SouthAfrica)
			{
				countHandler.TintColor(new Color32(56,218,56,255));
			}
		}
	}
}
