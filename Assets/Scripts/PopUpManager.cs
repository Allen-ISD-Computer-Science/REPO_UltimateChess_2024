using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public float displayDuration = 2f; // Duration to display the pop-up message
    private Text popupText;

    private void Start()
    {
        popupText = GetComponent<Text>();
        HidePopUp(); // Hide the pop-up text initially
    }

    public void ShowPopUp(string message)
    {
        popupText.text = message;
        gameObject.SetActive(true);
        Invoke(nameof(HidePopUp), displayDuration); // Hide the pop-up after display duration
    }

    private void HidePopUp()
    {
        gameObject.SetActive(false);
    }
}
