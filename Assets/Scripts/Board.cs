using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] Tokens = new GameObject[24];
    public Vector3[] Coordinates = new Vector3[24];

    void Start()
    {
        Coordinates[0] = transform.GetChild(0).gameObject.transform.position;
        Coordinates[1] = transform.GetChild(1).gameObject.transform.position;
        Coordinates[2] = transform.GetChild(2).gameObject.transform.position;
        Coordinates[3] = transform.GetChild(3).gameObject.transform.position;
        Coordinates[4] = transform.GetChild(4).gameObject.transform.position;
        Coordinates[5] = transform.GetChild(5).gameObject.transform.position;
        Coordinates[6] = transform.GetChild(6).gameObject.transform.position;
        Coordinates[7] = transform.GetChild(7).gameObject.transform.position;
        Coordinates[8] = transform.GetChild(8).gameObject.transform.position;
        Coordinates[9] = transform.GetChild(9).gameObject.transform.position;
        Coordinates[10] = transform.GetChild(10).gameObject.transform.position;
        Coordinates[11] = transform.GetChild(11).gameObject.transform.position;
        Coordinates[12] = transform.GetChild(12).gameObject.transform.position;
        Coordinates[13] = transform.GetChild(13).gameObject.transform.position;
        Coordinates[14] = transform.GetChild(14).gameObject.transform.position;
        Coordinates[15] = transform.GetChild(15).gameObject.transform.position;
        Coordinates[16] = transform.GetChild(16).gameObject.transform.position;
        Coordinates[17] = transform.GetChild(17).gameObject.transform.position;
        Coordinates[18] = transform.GetChild(18).gameObject.transform.position;
        Coordinates[19] = transform.GetChild(19).gameObject.transform.position;
        Coordinates[20] = transform.GetChild(20).gameObject.transform.position;
        Coordinates[21] = transform.GetChild(21).gameObject.transform.position;
        Coordinates[22] = transform.GetChild(22).gameObject.transform.position;
        Coordinates[23] = transform.GetChild(23).gameObject.transform.position;

    }
    public void MoveToken(GameObject token, int initialPosition, int finalPosition)
    {
        if (initialPosition != -1) Tokens[initialPosition] = null;
        Tokens[finalPosition] = token;
    }

    public void RemoveToken(int position)
    {
        var token = Tokens[position];
        Tokens[position] = null;
        Destroy(token);
    }

}
