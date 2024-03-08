using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class TerritoryHandler : MonoBehaviour {

	public Territory territory;

	private SpriteRenderer sprite;

	public Color32 oldColor;
	public Color32 startColor;
	public Color32 hoverColor;
	public bool hovering = false;
	public int player = 1;

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = startColor;
	}

	void OnMouseEnter() {
		oldColor = sprite.color;
		sprite.color = new Color32((byte)((int)oldColor.r + 10), (byte)((int)oldColor.g + 10), (byte)((int)oldColor.b + 10), 255);
		hovering = true;

    }

    void OnMouseExit() {
		if (sprite.color != new Color32((byte)((int)oldColor.r + 20), (byte)((int)oldColor.g + 20), (byte)((int)oldColor.b + 20), 255))
		{
			sprite.color = oldColor;
		}
		hovering = false;
		//This causes a minor problem where the territory appears to become unclicked after the cursor leaves it, it should only exist for the MVP, since once territories change how they should, this wont be needed anymore.
        TerritoryManager.instance.TintTerritories();
    }

    private void OnMouseDown() {
		sprite.color = new Color32((byte)((int)oldColor.r + 20), (byte)((int)oldColor.g + 20), (byte)((int)oldColor.b + 20), 255);
	}

	private void OnMouseUp()
	{
		switch (player) {
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
        TerritoryManager.instance.TintTerritories();
        startColor = sprite.color;
        oldColor = startColor;

        if (hovering == true)
		{
			sprite.color = new Color32((byte)((int)oldColor.r + 10), (byte)((int)oldColor.g + 10), (byte)((int)oldColor.b + 10), 255);
		} else {
			sprite.color = oldColor;
		}
    }
    private void Update() {
		//A little messy, but shouldnt be a part of anything but the mvp
		if (Input.GetKey(KeyCode.Alpha1)) {
			player = 1;
		} else if (Input.GetKey(KeyCode.Alpha2)) {
			player = 2;
		}
        else if (Input.GetKey(KeyCode.Alpha3)) {
            player = 3;
        }
        else if (Input.GetKey(KeyCode.Alpha4)) {
            player = 4;
        }
        else if (Input.GetKey(KeyCode.Alpha5)) {
            player = 5;
        }
        else if (Input.GetKey(KeyCode.Alpha6)) {
            player = 6;
        }
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
