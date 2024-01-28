using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Territory 
{
	public string name;
	
	public enum Regions{
		Oceania,
		Asia,
		EastEurope,
		WestEurope,
		NorthAfrica,
		SouthAfrica,
		Canada,
		UnitedStates,
		SouthAmerica
	}
	
	public Regions region;

	public int moneyReward;
}
