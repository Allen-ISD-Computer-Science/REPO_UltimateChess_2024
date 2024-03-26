using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class bottomBar : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject available = GameObject.Find("EndTurnAvailable");
    GameObject pressed = GameObject.Find("EndTurnPressed");
    GameObject locked = GameObject.Find("EndTUrnLocked");
    public int turns = 0;
    void Start()
    {
        available.SetActive(false);
        pressed.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            available.SetActive(true);
            locked.SetActive(false);
        }
        if (Input.GetMouseButtonDown(1) && gameObject.CompareTag("EndTurnAvailable"))
        {
            available.SetActive(false);
            pressed.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1) && gameObject.CompareTag("EndTurnPressed"))
        {
            locked.SetActive(true);
            pressed.SetActive(false);
            turns += 1;
        }
    }
}
