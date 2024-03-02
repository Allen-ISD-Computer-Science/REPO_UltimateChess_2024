using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class TerritoryHandler : MonoBehaviour {

	public Territory territory;

	private SpriteRenderer sprite;

	public Color32 oldColor;
	public Color32 startColor;
	public Color32 hoverColor;

	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
		sprite.color = startColor;
	}

	void OnMouseEnter() {
		oldColor = sprite.color;
		sprite.color = new Color32((byte)((int)oldColor.r + 10), (byte)((int)oldColor.g + 10), (byte)((int)oldColor.b + 10), 255);
	}

	void OnMouseExit() {
		if (sprite.color != new Color32((byte)((int)oldColor.r + 20), (byte)((int)oldColor.g + 20), (byte)((int)oldColor.b + 20), 255))
		{
			sprite.color = oldColor;
		}
	}

	private void OnMouseDown() {
		sprite.color = new Color32((byte)((int)oldColor.r + 20), (byte)((int)oldColor.g + 20), (byte)((int)oldColor.b + 20), 255);
	}

	private void OnMouseUp()
	{
        // There needs to be a check here for if the mouse is still hovering over the territory or not, since if its not it needs to turn to oldcolor instead of oldcolor + 10.
        if (sprite.color != oldColor)
		{
			sprite.color = new Color32((byte)((int)oldColor.r + 10), (byte)((int)oldColor.g + 10), (byte)((int)oldColor.b + 10), 255);
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
