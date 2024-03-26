using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    // References
    public GameObject controller;
    public GameObject movePlate;

    // Positions
    private int xBoard = -1;
    private int yBoard = -1;

    // Variable, keep track of black or white
    private string player;

    // References for all sprites
    public Sprite black_queen, black_knight, black_bishop, black_king, black_rook, black_pawn;
    public Sprite white_queen, white_knight, white_bishop, white_king, white_rook, white_pawn;

    public void Activate()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");

        // Take instantiated location and adjust transform
        SetCoords();

        switch (this.name)
        {
            case "black queen": this.GetComponent<SpriteRenderer>().sprite = black_queen; break;
            case "black knight": this.GetComponent<SpriteRenderer>().sprite = black_knight; break;
            case "black king": this.GetComponent<SpriteRenderer>().sprite = black_king; break;
            case "black rook": this.GetComponent<SpriteRenderer>().sprite = black_rook; break;
            case "black pawn": this.GetComponent<SpriteRenderer>().sprite = black_pawn; break;

            case "white queen": this.GetComponent<SpriteRenderer>().sprite = white_queen; break;
            case "white knight": this.GetComponent<SpriteRenderer>().sprite = white_knight; break;
            case "white king": this.GetComponent<SpriteRenderer>().sprite = white_king; break;
            case "white rook": this.GetComponent<SpriteRenderer>().sprite = white_rook; break;
            case "white pawn": this.GetComponent<SpriteRenderer>().sprite = white_pawn; break;

        }
    }

    public void SetCoords()
    {
        float x = xBoard;
        float y = yBoard;

        x *= 0.66f;
        y *= 0.66f;

        x += -2.3f;
        y += -2.3f;

        this.transform.position = new Vector3(x, y, -1.0f);
    }

    public int GetXBoard()
    {
        return xBoard;
    }

    public int GetYBoard()
    {
        return yBoard;
    }

    public void SetXBoard(int x)
    {
        xBoard = x;
    }

    public void SetYBoard(int y)
    {
        yBoard = y;
    }
}
