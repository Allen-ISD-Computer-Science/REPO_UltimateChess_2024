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
		Europe,
		NorthAfrica,
		SouthAfrica,
		Canada,
		UnitedStates,
		SouthAmerica
	}
	
	public enum Players{
		Player1,
		Player2,
		Player3,
		Player4,
		Player5,
		Player6
	}
	
	public Regions region;
	
	public Players player;

	public int moneyReward;
	
}
