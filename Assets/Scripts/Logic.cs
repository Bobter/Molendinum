using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic
{

    public int[] Board { get; } = new int[24]; //24 posiciones en el tablero del NMM
    public int MeninGame { get; } = new int[2] { 0, 0 }; //Fichas en el tablero(al iniciar el juego son 0 para los 2 jugadores)
    public int Men { get; } = new int[2] { 9, 9 }; //Fichas disponibles para los jugadores
    
    //Definiendo MOLINOS y VECINOS
    private static List<Tuple<int, int, int>> Molindenum = new List<Tuple<int, int, int>>();
    public static List<int>[] Neighbour = new List<int>[24];    //Hay 24 vecinos 
    void Rules() { 
        //MOLINOS
        for (int i = 0; i <8; i++)
        {
            Molindenum.Add(Tuple.Create(0+(3*i), 1 + (3*i), 2 + (3*i))); //Molinos en horizontal
        }
        for (int i = 0; i<3; i++) 
        {
            //Molinos en vertical (FALTAN 2)
            Molindenum.Add(Tuple.Create(0+(3*i), 9+i, 21-(3*i))); 
            Molindenum.Add(Tuple.Create(8-(3*i), 12+i, 17+(3*i)));
        }
        //Molinos en vertical que FALTARON
        Molindenum.Add(Tuple.Create(1, 4, 7));
        Molindenum.Add(Tuple.Create(16, 19, 22));

        //VECINOS
        for (int i=0; i<8; i++) 
        {
            //Vecinos hacia la derecha
            Neighbour[0 + (3*i)].Add(1 + (3+i));
            Neighbour[1 + (3*i)].Add(2 + (3+i));
            //Vecinos hacia la izquierda
            Neighbour[23 - (3 * i)].Add(22 - (3 + i));
            Neighbour[22 - (3 * i)].Add(21 - (3 + i));
        }
        for (int i = 0; i < 3; i++)
        {
            //FALTAN LOS VECINOS CENTRALES SUPERIORES E INFERIORES
            //Vecinos hacia abajo
            Neighbour[0+(3*i)].Add(9+i);
            Neighbour[9+(i)].Add(21-(3*i));
            Neighbour[8 - (3 * i)].Add(12+i);
            Neighbour[12+i].Add(17+(3*i));
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
            Neighbour[1+(i*3)].Add(4 + (i * 3));
            Neighbour[16+ (i * 3)].Add(19 + (i * 3));
            //Vecinos hacia arriba
            Neighbour[7 - (i * 3)].Add(4 - (i * 3));
            Neighbour[22 - (i * 3)].Add(19 - (i * 3));
        }

    }
}
