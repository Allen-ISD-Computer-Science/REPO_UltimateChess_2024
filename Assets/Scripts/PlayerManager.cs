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
    private bool hasInitialized = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize player territories with initial assignments
        InitializePlayerTerritories();
    }

    // Method to initialize player territories with initial assignments
    void InitializePlayerTerritories()
    {
        // Find all TerritoryHandler components in the scene
        TerritoryHandler[] territories = FindObjectsOfType<TerritoryHandler>();

        foreach (var territory in territories)
        {
            int playerID = territory.player; // Get the player assigned to the territory
            if (!playerTerritories.ContainsKey(playerID))
            {
                playerTerritories[playerID] = new List<TerritoryHandler>();
            }
            playerTerritories[playerID].Add(territory);
        }

        // Set initialization flag to true
        hasInitialized = true;

        // Check player status after initialization
        CheckPlayerStatus();
    }


    // Update territory ownership
    public void UpdateTerritoryOwnership(TerritoryHandler territory, int newPlayer)
    {
        // Remove territory from previous player's list
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

    // Mark player as eliminated
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

    // Check if player is eliminated
    public bool IsPlayerEliminated(int playerID)
    {
        return eliminatedPlayers.Contains(playerID);
    }

    // Check player status
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

        Debug.Log("Active player count: " + activePlayerCount);

        // Check if there are at least two active players remaining
        if (activePlayerCount >= 2)
        {
            // At least two players left, check if the scene needs to be changed
            if (activePlayerCount == 2 && SceneManager.GetActiveScene().name != "Chess")
            {
                SceneManager.LoadScene("Chess");
            }
        }
        else
        {
            // Less than two players left, continue the game
            Debug.Log("Waiting for more eliminations before changing scene.");
        }
    }
}