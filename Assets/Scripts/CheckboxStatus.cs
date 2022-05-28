using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckboxStatus : MonoBehaviour
{
    public bool checkboxAvailable;
    public int checkboxIndex;
    //si el jugador tiene el indice 1 entonces la ficha es de color blanco
    //si el jugador tiene el indice 0 entonces la ficha es de color negro
    public int tokenPlayerIndex;
    public Token currentToken;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        checkboxAvailable = true;
        tokenPlayerIndex = -1;
        GameObject.FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("token") && checkboxAvailable == true && currentToken == null)
        {
            Debug.Log("!LLEGO LA FICHA");
            tokenPlayerIndex = other.gameObject.transform.GetComponent<Token>().playerIndex;
            Debug.Log("JUGADOR " + tokenPlayerIndex + ", POSICION " + checkboxIndex);
            if (gameManager.movementIndexes[1] == checkboxIndex)
            {
                currentToken = other.GetComponent<Token>();
                checkboxAvailable = false;
                gameManager.makeMill = gameManager.rules.Mill(checkboxIndex, gameManager.board, gameManager.currentPlayerIndex);
                if (!gameManager.makeMill)
                {
                    Debug.Log("SIGUIENTE TURNO");
                    gameManager.NextTurn();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.CompareTag("token") && checkboxAvailable == false && currentToken.gameObject == other.gameObject)
        {
            Debug.Log("INICIA SALIDA");
            tokenPlayerIndex = -1;
            currentToken = null;
            checkboxAvailable = true;
            Debug.Log("TERMINA SALIDA");
        }
    }
}