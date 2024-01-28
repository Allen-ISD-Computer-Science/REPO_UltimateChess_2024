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
	
	void OnMouseEnter(){
		oldColor = sprite.color;
		sprite.color = hoverColor;
	}

	void OnMouseExit(){
		sprite.color = oldColor;
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
