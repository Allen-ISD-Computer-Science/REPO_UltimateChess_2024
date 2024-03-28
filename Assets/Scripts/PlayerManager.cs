using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Track player territories
    private Dictionary<int, List<TerritoryHandler>> playerTerritories = new Dictionary<int, List<TerritoryHandler>>();
    public List<int> eliminatedPlayers = new List<int>();

    // Update territory ownership
    public void UpdateTerritoryOwnership(TerritoryHandler territory, int newPlayer)
    {
        // Remove territory from previous player's list if it exists
        foreach (var playerTerritoryList in playerTerritories.Values)
        {
            playerTerritoryList.Remove(territory);
        }

        // Add territory to new player's list
        if (!playerTerritories.ContainsKey(newPlayer))
        {
            playerTerritories[newPlayer] = new List<TerritoryHandler>();
        }
        playerTerritories[newPlayer].Add(territory);

        // Check player status after territory ownership update
        CheckPlayerStatus();
    }

    public void MarkPlayerAsEliminated(int playerID)
    {
        if (!eliminatedPlayers.Contains(playerID))
        {
            eliminatedPlayers.Add(playerID);
            Debug.Log("Player " + playerID + " has been marked as eliminated.");

            // Check player status after elimination
            CheckPlayerStatus();
        }
    }

    public bool IsPlayerEliminated(int playerID)
    {
        return eliminatedPlayers.Contains(playerID);
    }

    public void CheckPlayerStatus()
    {
        int activePlayerCount = 6 - eliminatedPlayers.Count;

        foreach (var playerID in playerTerritories.Keys.ToList())
        {
            List<TerritoryHandler> territoryList = playerTerritories[playerID];
            if (territoryList.Count == 0 && !IsPlayerEliminated(playerID))
            {
                // Player has no territories left, mark as eliminated
                MarkPlayerAsEliminated(playerID);
                Debug.Log("Player " + playerID + " has been eliminated.");
            }
        }
        
        // Exactly 2 players left, change scene
        if (activePlayerCount == 2 && SceneManager.GetActiveScene().name != "Chess")
        {
            SceneManager.LoadScene("Chess");
        }
    }
}