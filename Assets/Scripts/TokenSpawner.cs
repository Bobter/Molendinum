using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public Token TokenPrefab;
    // Start is called before the first frame update

    public Token[,] spawnTokens(int maxTokens)//instanciar las fichas con sus valores iniciales 
    {
        Token [,]arrayToken = new Token[2, maxTokens];//crea una matriz de objetos de clase Token de tamaño 2 x maxTokens
        for (int i = 0; i < (maxTokens * 2); i++)
        {
            Token token = Instantiate(TokenPrefab, gameObject.transform.position, Quaternion.identity);//se crea una casilla
            token.gameObject.SetActive(false);//inicialmente se desactiva
            if (i < maxTokens)//para la primera mitad de las fichas totales
            {
                token.SetTokenOwner(0);//serán del jguador 1
                arrayToken[0, i] = token;//se guarda en el indice [0][i] de la matriz
            }
            else//para la segunda mitad de las fichas totales
            {
                token.SetTokenOwner(1);//serán del jguador 2
                arrayToken[1, i - maxTokens] = token;//se guarda en el indice [1][i] de la matriz
            }
        }
        return arrayToken;
    }
}
