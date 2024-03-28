using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(PolygonCollider2D))]
public class TerritoryHandler : MonoBehaviour
{
    public Territory territory;
    private SpriteRenderer sprite;

    public Color32 oldColor;
    public Color32 startColor;
    public bool hovering = false;
    public int player = 1;

    private PlayerManager playerManager;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = startColor;

        playerManager = FindObjectOfType<PlayerManager>();
        if (playerManager == null)
        {
            Debug.LogError("PlayerManager not found in the scene!");
        }
    }

    void OnMouseEnter()
    {
        oldColor = sprite.color;
        sprite.color = new Color32((byte)(oldColor.r + 10), (byte)(oldColor.g + 10), (byte)(oldColor.b + 10), 255);
        hovering = true;
    }

    void OnMouseExit()
    {
        if (sprite.color != new Color32((byte)(oldColor.r + 20), (byte)(oldColor.g + 20), (byte)(oldColor.b + 20), 255))
        {
            sprite.color = oldColor;
        }
        hovering = false;
        TerritoryManager.instance.TintTerritories();
    }

    void OnMouseDown()
    {
        if (playerManager.IsPlayerEliminated(player))
        {
            // Player is eliminated, do not allow color change
            return;
        }

        sprite.color = new Color32((byte)(oldColor.r + 20), (byte)(oldColor.g + 20), (byte)(oldColor.b + 20), 255);
    }

    void OnMouseUp()
    {
        if (playerManager.IsPlayerEliminated(player))
        {
            // Player is eliminated, do not allow territory ownership change
            return;
        }

        switch (player)
        {
            case 1:
                territory.player = Territory.Players.Player1;
                break;
            case 2:
                territory.player = Territory.Players.Player2;
                break;
            case 3:
                territory.player = Territory.Players.Player3;
                break;
            case 4:
                territory.player = Territory.Players.Player4;
                break;
            case 5:
                territory.player = Territory.Players.Player5;
                break;
            case 6:
                territory.player = Territory.Players.Player6;
                break;
        }

        playerManager.UpdateTerritoryOwnership(this, player);

        TerritoryManager.instance.TintTerritories();
        startColor = sprite.color;
        oldColor = startColor;

        if (hovering)
        {
            sprite.color = new Color32((byte)(oldColor.r + 10), (byte)(oldColor.g + 10), (byte)(oldColor.b + 10), 255);
        }
        else
        {
            sprite.color = oldColor;
        }
    }

    public void ChangePlayer(int currentPlayerIndex)
    {
        player = currentPlayerIndex + 1;
    }

    void OnDrawGizmos()
    {
        territory.name = name;
        this.tag = "Territory";
    }

    public void TintColor(Color32 color)
    {
        sprite.color = color;
    }
}