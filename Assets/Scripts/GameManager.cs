using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool makeMill;//es verdadero si se formó un molino en el turno y es falso cuando no
    public Logic rules;
    public Board board;
    public Text win;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerIndex = 0;
        rules = gameObject.GetComponent<Logic>();
        board = GameObject.FindObjectOfType<Board>();
        spawnTokens();
    }
    // Update is called once per frame
    void Update()
    {
        if (Victory())//si ya hay una victoria
        {
            if (win != null) {//si existe el texxto de victoria
                if (currentPlayerIndex == 0) win.color = Color.black;//si la victoria es del jugador 1 entonces el color del texto es negro, 
                else win.color = Color.white;//si es del jugador 2 entonces el texto es blanco
                win.gameObject.SetActive(true);
            }
        }else if(Input.GetKeyDown(KeyCode.Mouse0))//si no hay victoria y se preciona el click izquierdo del mouse
        {
            if (makeMill) DeleteToken();//si se hace un molino entonces se debe eliminar una ficha del oponente
            else MoveToken();//si no se hace un molino entonces los jugadores deberán seguir colocando sus fichas en el tablero o moverlas por las casillas
        }
    }

    public void NextTurn()//cambia al turno siguiente
    {
        currentPlayerIndex = ((currentPlayerIndex +1)% 2);
    }
    public bool Victory()//retorna verdadero si es que ya hay una victoria
    {          //si el otro jugador que no es el actual tine 2 fichas o menos enotnces es una victoria para el jugador actual ,si no ocurre esto entonces no hay victoria
        return (availableTokens[(currentPlayerIndex + 1) % 2] <= 2) ? true : false;
    }
    public void selectingNothing()//resetea los valores de los indices de movimiento , de la ficha seleccionada y de la casilla seleccionada
    {
        movementIndexes[0] = -1;
        movementIndexes[1] = -1;
        SelectedToken = null;
        box = null;
    }
    public void spawnTokens()//instanciar las fichas con sus valores iniciales 
    {
        arrayToken = new Token[2, maxTokens];//crea una matriz de objetos de clase Token de tamaño 2 x maxTokens
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
    }
    public void MoveToken()//función de selección del objeto
    {
        RaycastHit hit;
        Ray mouseDirection = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mouseDirection.origin, mouseDirection.direction, out hit, maxDistance))//si el rayo choca con algo
        {
            if (placedTokens[currentPlayerIndex]<maxTokens)//cuando el jugador del turno actual aún no coloca todas sus fichas 
            {
                 if (hit.transform.CompareTag("box") )//si selecciona una casilla
                {
                    box = hit.transform.GetComponent<CheckboxStatus>();
                    SelectedToken= arrayToken[currentPlayerIndex, placedTokens[currentPlayerIndex]];
                    SelectedToken.gameObject.SetActive(true);
                    SelectedToken.transform.position =box.transform.position;
                    placedTokens[currentPlayerIndex] += 1;
<<<<<<< Updated upstream
                    movementIndexes[0] = currentPlayerIndex;
                    movementIndexes[1] = box.checkboxIndex; 
=======
                    movementIndexes[1] = SelectedCheckbox.checkboxIndex; 
>>>>>>> Stashed changes
                }
            }else//cuando ya tiene colocada las fichas en el tablero
            {
                if (hit.transform.CompareTag("token"))//si selecciona una ficha
                {
                    if (hit.transform.GetComponent<Token>().playerIndex == currentPlayerIndex) SelectedToken = hit.transform.GetComponent<Token>();
                }
                else if (hit.transform.CompareTag("box") && SelectedToken != null)//si selecciona una casilla luego de seleccionar la ficha que quiere mover
                {
                    box = hit.transform.GetComponent<CheckboxStatus>();//se guarda la casilla
                    movementIndexes[0] = SelectedToken.checkboxIndex;//se guarde el indice de la casilla actual del jugador 
                    movementIndexes[1] = box.checkboxIndex;//se guarda la casilla a donde se quiere llegar
                    if (rules.ValidMovement(movementIndexes[0], movementIndexes[1],board,currentPlayerIndex))StartCoroutine(SelectedToken.Move(box.transform.position));//si es un movimineto válido entonces la ficha se mueve a la casilla seleccionada
                    
                }else selectingNothing();//si da click a otra parte del tablero entonces se restablecen los valoes guardados
            }
        }else selectingNothing();//si no choca con nada entonces se restablecen los valoes guardados
    }
   
    void DeleteToken()
    {
        RaycastHit hit;
        Ray mouseDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
        int deleteTokenIndex = (currentPlayerIndex + 1) % 2;
        if (Physics.Raycast(mouseDirection.origin, mouseDirection.direction, out hit, maxDistance))//si el rayo choca con algo
        {
            if (hit.transform.CompareTag("token")&& hit.transform.GetComponent<Token>().playerIndex == deleteTokenIndex)//si selecciona una ficha 
            {
                 Token deletedToken = hit.transform.GetComponent<Token>();
                 availableTokens[deleteTokenIndex] -= 1;//se resta 1 a la cantidad de fichas del otro jugador
                 deletedToken.Delete();//se elimina la ficha  seleccionada
                 makeMill = false;// terminó la eliminación de la ficha 
                 if (!Victory())NextTurn();//si es que no hay victoria entocnes sigue el turno del otro jugador
            }
        }     
    }
}
