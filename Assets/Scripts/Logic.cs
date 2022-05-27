using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class Logic : MonoBehaviour
{       
    //Definiendo MOLINOS y VECINOSD
    private static List<Tuple<int, int, int>> Molindenum = new List<Tuple<int, int, int>>();
    public  List<int>[] Neighbour = new List<int>[24];    //Hay 24 posiciones

    //Obteniendo posiciones
    public GameManager GM;
    void Start()
    {
        GM = gameObject.GetComponent<GameManager>();
        Rules();
    }

    void Rules()
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

            //VECINOS
            for (int i = 0; i < 8; i++)
            {
                //Vecinos hacia la derecha
                Neighbour[0 + (3 * i)].Add(1 + (3 + i));
                Neighbour[1 + (3 * i)].Add(2 + (3 + i));
                //Vecinos hacia la izquierda
                Neighbour[23 - (3 * i)].Add(22 - (3 + i));
                Neighbour[22 - (3 * i)].Add(21 - (3 + i));
            }
            for (int i = 0; i < 3; i++)
            {
                //FALTAN LOS VECINOS CENTRALES SUPERIORES E INFERIORES
                //Vecinos hacia abajo
                Neighbour[0 + (3 * i)].Add(9 + i);
                Neighbour[9 + (i)].Add(21 - (3 * i));
                Neighbour[8 - (3 * i)].Add(12 + i);
                Neighbour[12 + i].Add(17 + (3 * i));
                //Vecinos hacia arriba 
                Neighbour[11 - i].Add(6 - (3 * i));
                Neighbour[15 - (3 * i)].Add(11 - i);
                Neighbour[14 - i].Add(2 + (3 * i));
                Neighbour[23 - (3 * i)].Add(14 - i);
            }
            for (int i = 0; i < 2; i++)
            {
                //VECINOS CENTRALES SUPERIORES E INFERIORES
                //Vecinos restantes 
                //Vecinos hacia abajo
                Neighbour[1 + (i * 3)].Add(4 + (i * 3));
                Neighbour[16 + (i * 3)].Add(19 + (i * 3));
                //Vecinos hacia arriba
                Neighbour[7 - (i * 3)].Add(4 - (i * 3));
                Neighbour[22 - (i * 3)].Add(19 - (i * 3));
            }
            
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
        if (Neighbour[begin].Contains(end))
            return true;
        if (GM.availableTokens[CurrentPlayer]==3)
            return true;


        return false;
    }


    
}
