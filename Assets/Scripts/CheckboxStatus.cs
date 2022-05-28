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
        gameManager = GameObject.FindObjectOfType<GameManager>();
        tokenPlayerIndex = -1;
    }
    void Update()
    {

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.CompareTag("token") && checkboxAvailable == false && currentToken == other.GetComponent<Token>())
        {
            Debug.Log("INICIA SALIDA");
            tokenPlayerIndex = -1;
            currentToken = null;
            checkboxAvailable = true;
            Debug.Log("TERMINA SALIDA");
            /*if (gameManager.makeMill)
            {
                gameManager.makeMill = gameManager.rules.Mill(checkboxIndex, gameManager.board, gameManager.currentPlayerIndex);
            }*/
          
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("token") && checkboxAvailable == true && currentToken == null)
        {
            Debug.Log("LLEGUOO LA FICHA");
            //tokeIndex captura el indice de la ficha entrante
            tokenPlayerIndex = other.gameObject.transform.GetComponent<Token>().playerIndex;
            Debug.Log("---PLAYER " + tokenPlayerIndex + " IN POSITIION " + checkboxIndex);
            if (gameManager.movementIndexes[1]==checkboxIndex)/////////////////////////
            {
                currentToken = other.GetComponent<Token>();
                checkboxAvailable = false;
                gameManager.makeMill = gameManager.rules.Mill(checkboxIndex, gameManager.board, gameManager.currentPlayerIndex);
                if (!gameManager.makeMill&&!gameManager.Victory())
                {
                    Debug.Log("SIGUIENTE TURNO");
                    gameManager.NextTurn();
                }
                
            }

        }
    }

   
}
