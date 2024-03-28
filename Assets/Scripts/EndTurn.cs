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
        // Adjust the player index for display (starting from 1)
        string playerName = (currentPlayerIndex + 1).ToString();
        popUpManager.ShowPopUp("Player " + playerName + " has ended their turn!");

        // Increment the currentPlayerIndex for the next turn
        currentPlayerIndex++;

        // If the index exceeds the number of players, reset it to 0
        if (currentPlayerIndex >= 6) // Assuming there are 6 players
        {
            currentPlayerIndex = 0;
        }

        // Change player index in TerritoryManager
        territoryManager.ChangePlayers(currentPlayerIndex);
    }
}