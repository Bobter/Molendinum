using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Logic : MonoBehaviour
{       
    //Definiendo MOLINOS y VECINOSD
    public List<int[]> Molendinum = new List<int[]>();
    public int[,] Neighbour = {{1,9,0,0},   //0
                            {0,2,4,1},      //1
                            {1,14,2,2},     //2
                            {4,10,3,3},     //3
                            {1,3,5,7},      //4
                            {4,13,5,5},     //5
                            {7,11,6,6},     //6
                            {4,6,8,7},      //7
                            {7,12,8,8},     //8
                            {0,10,21,9},    //9
                            {3,9,11,18},    //10
                            {6,10,15,11},   //11
                            {8,13,17,12},   //12
                            {5,12,14,20},   //13
                            {2,13,23,14},   //14
                            {11,16,15,15},  //15
                            {15,17,19,16},  //16
                            {12,16,17,17},  //17
                            {10,19,18,18},  //18
                            {16,18,20,22},  //19
                            {13,19,20,20},  //20
                            {9,22,21,21},   //21
                            {19,21,23, 22}, //22
                            {14,22,23,23},  //23
                            };  //Hay 24 posiciones

    public GameManager GM;
    //Inicializando Rules
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
            //Molinos en horizontal
            Molendinum.Add(new int[] { 0 + (3 * i), 1 + (3 * i), 2 + (3 * i) });
        }
        for (int i = 0; i < 3; i++)
        {
            //Molinos en vertical (FALTAN 2)
            Molendinum.Add(new int[] { 0 + (3 * i), 9 + i, 21 - (3 * i) });
            Molendinum.Add(new int[] { 8 - (3 * i), 12 + i, 17 + (3 * i) });
        }
        //Molinos en vertical que FALTARON
        Molendinum.Add(new int[] { 1, 4, 7 });
        Molendinum.Add(new int[] { 16, 19, 22 });
    }
    
    //Funcion que comprueba si hay un Molino(3 en raya)
    //Entrada checkbox.currentIndex y Board 
    public bool Mill(int position, Board boardN, int CurrentPlayer)
    {
        UnityEngine.Debug.Log("------POSITION-------:"+position);
        for (int i = 0; i < 15; i++)
        {
            UnityEngine.Debug.Log(i+": "+Molendinum[i][0]);
            UnityEngine.Debug.Log(i + ": " + Molendinum[i][1]);
            UnityEngine.Debug.Log(i + ": " + Molendinum[i][2]);
            if (position == Molendinum[i][0] || position == Molendinum[i][1] || position == Molendinum[i][2])
            {
                UnityEngine.Debug.Log("Ya llegue");
                UnityEngine.Debug.Log(position);
                UnityEngine.Debug.Log(boardN.Checkbox[Molendinum[i][0]].tokenPlayerIndex);
                UnityEngine.Debug.Log(boardN.Checkbox[Molendinum[i][1]].tokenPlayerIndex);
                UnityEngine.Debug.Log(boardN.Checkbox[Molendinum[i][1]].tokenPlayerIndex);
                if (boardN.Checkbox[Molendinum[i][0]].tokenPlayerIndex == CurrentPlayer && boardN.Checkbox[Molendinum[i][1]].tokenPlayerIndex == CurrentPlayer && boardN.Checkbox[Molendinum[i][2]].tokenPlayerIndex == CurrentPlayer) 
                {
                    UnityEngine.Debug.Log("Ya llegue");
                    return true;
                }
            }
        }
        return false;
    }

    //Nos da un booleano que nos dice si una ficha se puede eliminar si es que no forma parte de un molino
    public bool Remove(int BoardPos, Board boardL, int CurrentPlayer) 
    {
        return !Mill(BoardPos, boardL,CurrentPlayer);
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
