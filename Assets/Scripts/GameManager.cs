using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPlayerIndex;
    public int maxTokens = 9;
    public bool twoPlayers=true;
    public float maxDistance;
    public CheckboxStatus box;
    public Token SelectedToken;
    public Token TokenPrefab;
    public bool finishMoveToken=false;
    public int[] placedTokens = { 0, 0 };//contador de las fichas colocadas
    public int[] availableTokens = { 9, 9 };//contador de la cantidad de fichas activas

    public int []movementIndexes = { -1,-1 };//indice de la casilla de la ficha y de la casilla a la que se quiere desplazar
    public Token[,] arrayToken;
    bool makeMill;//es verdadero si se formó un molino en el turno y es falso cuando no
    Logic rules;
    Board board;
    // Start is called before the first frame update
    void Start()
    {
        rules = gameObject.GetComponent<Logic>();
        board = GameObject.FindObjectOfType<Board>();
        spawnTokens();
    }

    // Update is called once per frame
    void Update()
    {
        /*Ray direction = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(direction.origin, direction.direction * maxDistance, Color.cyan);*/

        
        if (finishMoveToken)
        {
            makeMill = rules.Mill(movementIndexes[1], board);
            finishMoveToken = false;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                SelecObject();
            }
        }
        /*
        if (makeMill)
        {
            deleteToken();
        }
        else NextTurn();*/
       
    }

    public void NextTurn()
    {
        currentPlayerIndex = ((currentPlayerIndex +1)% 2);
    }
    public void SelecObject()//función de selección del objeto
    {
        RaycastHit hit;
        Ray mouseDirection = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseDirection.origin, mouseDirection.direction, out hit, maxDistance))//si el rayo choca con algo
        {
            if (placedTokens[currentPlayerIndex]<9)//cuando el jugador del turno actual aún no coloca todas sus fichas 
            {
                 if (hit.transform.CompareTag("box") )
                {

                    arrayToken[currentPlayerIndex, placedTokens[currentPlayerIndex]].activeToken(true);
                    arrayToken[currentPlayerIndex, placedTokens[currentPlayerIndex]].transform.position = hit.transform.position;
                    placedTokens[currentPlayerIndex] += 1;
                    NextTurn();
                }
            }

            else//cuando ya tiene colocada las fichas en el tablero
            {
                if (hit.transform.CompareTag("token"))//si selecciona una ficha
                {
                    if (hit.transform.GetComponent<Token>().playerIndex == currentPlayerIndex)
                    {
                        SelectedToken = hit.transform.GetComponent<Token>();

                    }
                    Debug.Log("ficha");
                }
                else if (hit.transform.CompareTag("box") && SelectedToken != null)//si selecciona una casilla y seleccionó antes la ficha a mover
                {
                    Debug.Log("mover a");
                    box = hit.transform.GetComponent<CheckboxStatus>();
                    movementIndexes[0] = SelectedToken.checkboxIndex;
                    movementIndexes[1] = box.checkboxIndex;
                
                    if (rules.ValidMovement(movementIndexes[0], movementIndexes[1],board,currentPlayerIndex))
                    {
                        StartCoroutine(SelectedToken.Move(box.transform.position));
                        NextTurn();
                    }
                   
                }
                else
                {
                    selectingNothing();
                }
            }
        }
        else
        {
            selectingNothing();
        }

    }

    void deleteToken()
    {
        RaycastHit hit;
        Ray mouseDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
        int deleteTokenIndex = (currentPlayerIndex + 1) % 2;
        if (Physics.Raycast(mouseDirection.origin, mouseDirection.direction, out hit, maxDistance))//si el rayo choca con algo
        {
            if (hit.transform.CompareTag("token"))//si selecciona una fichaenemiga
            {
                Token deletedToken = hit.transform.GetComponent<Token>();
                if (deletedToken.playerIndex == deleteTokenIndex)
                {
                    deletedToken.DeleteToken();
                    makeMill = false;
                    NextTurn();
                }
            }
        }     
    }
    public void selectingNothing()
    {
        movementIndexes[0]=-1;
        movementIndexes[1]=-1;
        SelectedToken = null;
        box = null;
    }
    private void spawnTokens()
    {
        arrayToken= new Token[2,maxTokens] ;
        for (int i = 0; i < (maxTokens*2); i++)
        {
            Token player1 = Instantiate(TokenPrefab, gameObject.transform.position, Quaternion.identity);
            player1.activeToken(false);

            if (i < maxTokens) {
                player1.SetTokenOwner(0);
                arrayToken[0, i] = player1;
            }
            else
            {
                player1.SetTokenOwner(1);
                arrayToken[1, i-maxTokens] = player1;
            }  
        }
    }
}
