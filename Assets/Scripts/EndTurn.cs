using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
    private int currentPlayerIndex = 0;
    
    public PopUpManager popUpManager; 
    // Reference to the TerritoryManager script
    public TerritoryManager territoryManager;

    // Function to handle button click event
    public void IncrementPlayerIndexOnClick()
    {
        // Increment the currentPlayerIndex
        currentPlayerIndex++;

        // If the index exceeds the number of players, reset it to 0
        if (currentPlayerIndex >= 6) // Assuming there are 6 players
        {
            currentPlayerIndex = 0;
        }

        // Change player index in TerritoryManager
        territoryManager.ChangePlayers(currentPlayerIndex);

        string playerName = (currentPlayerIndex).ToString();
        popUpManager.ShowPopUp("Player " + playerName + " has ended their turn!");
    }
}