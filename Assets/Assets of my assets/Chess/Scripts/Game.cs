using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public GameObject chesspiece;

    private GameObject[,] positions = new GameObject[8, 8];
    private GameObject[] playerBlack = new GameObject[16];
    private GameObject[] playerWhite = new GameObject[16];


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(chesspiece, new Vector3(0, 0, -1), Quaternion.identity);
    }

}
