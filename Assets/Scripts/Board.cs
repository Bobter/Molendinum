using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject[] Tokens = new GameObject[24];
    public Vector3[] Coordinates = new Vector3[24];

    void Start()
    {

        //Capturamos las posiciones en un array
        for (int i = 0; i < 24; ++i)
        {
            Coordinates[i] = transform.GetChild(i).gameObject.transform.position;
        }

    }

    //Funcion quitar ficha
    public void RemoveToken(int position)
    {
        var token = Tokens[position];   //
        Tokens[position] = null;    //Reemplaza sus coordenadas por null
        Destroy(token); //Se destruye el objeto token en la respectiva posicion
    }

}
