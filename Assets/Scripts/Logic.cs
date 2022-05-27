using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class Logic : MonoBehaviour
{       
    //Definiendo MOLINOS y VECINOSD
    public List<Tuple<int, int, int>> Molindenum = new List<Tuple<int, int, int>>();
    public int[,] Neighbour = {{1,9,0,0},
                            {0,2,4,1},
                            {1,14,2,2},
                            {4,10,3,3},
                            {1,3,5,7},
                            {4,13,5,5},
                            {7,11,6,6},
                            {4,6,8,7},
                            {7,12,8,8},
                            {0,10,21,9},
                            {3,9,11,18},
                            {6,10,15,11},
                            {8,13,17,12},
                            {5,12,14,20},
                            {2,13,23,14},
                            {11,16,15,15},
                            {15,17,19,16},
                            {12,16,17,17},
                            {10,19,18,18},
                            {16,18,20,22},
                            {13,19,20,20},
                            {9,22,21,21},
                            {19,21,23, 22},
                            {14,22,23,23},
                            };  //Hay 24 posiciones

    //Obteniendo posiciones
    public GameManager GM;
    void Start()
    {
        GM = gameObject.GetComponent<GameManager>();
        Rules();
    }

    public void Rules()
    {
            //MOLINOS
            for (int i = 0; i < 8; i++)
            {
                Molindenum.Add(Tuple.Create(0 + (3 * i), 1 + (3 * i), 2 + (3 * i))); //Molinos en horizontal
            }
            for (int i = 0; i < 3; i++)
            {
                //Molinos en vertical (FALTAN 2)
                Molindenum.Add(Tuple.Create(0 + (3 * i), 9 + i, 21 - (3 * i)));
                Molindenum.Add(Tuple.Create(8 - (3 * i), 12 + i, 17 + (3 * i)));
            }
            //Molinos en vertical que FALTARON
            Molindenum.Add(Tuple.Create(1, 4, 7));
            Molindenum.Add(Tuple.Create(16, 19, 22));

            
            
    }
    
    //Funcion que comprueba si hay un Molino(3 en raya)

    //Entrada checkbox.currentIndex y Board 
    public bool Mill(int position, Board boardN)
    {
        var i = boardN.Coordinates[position];

        foreach(var p in Molindenum)
        {
            if (position == p.Item1 || position == p.Item2 || position == p.Item3)
            {
                if (boardN.Coordinates[p.Item1] == i && boardN.Coordinates[p.Item2] == i && boardN.Coordinates[p.Item2] == i) 
                {
                    return true;
                }
            }
        }
        return false;
    }

    //Nos da un booleano que nos dice si una ficha se puede eliminar si es que no forma parte de un molino
    public bool Remove(int BoardPos, Board boardL) 
    {
        return !Mill(BoardPos, boardL);
    }

    //Comprueba un movimiento valido
    public bool ValidMovement(int begin, int end, Board boardN, int CurrentPlayer)
    {
        GM = GameObject.FindObjectOfType<GameManager>();

        if (begin == end)
            return false;
        if (end < 0 || end >= boardN.Coordinates.Length)
            return false;
        if (begin < -1 || begin >= boardN.Coordinates.Length)
            return false;
        if (Neighbour[begin,0]==end || Neighbour[begin, 1] == end || Neighbour[begin, 2] == end || Neighbour[begin, 0] == end)
            return true;
        if (GM.availableTokens[CurrentPlayer]==3)
            return true;

        return false;
    }


    
}
