using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{   //varaibles privadas
    private Color tokenMeshColor;//guarda el color de la ficha 
    private bool selected;//booleano que indica si la ficha está o no seleccionada
    private GameManager gameManager;//adquiere el gameManager que hay en la escena
    int unplacedTokens;//variables extraida del manager que nos muestra cuantas fichas faltan colocar en el tablero
    CheckboxStatus currentCheckbox; 

    //variables públicas
    public int currentPlayerIndex;//indice del jugador del que es su turno
    public int playerIndex;//indice del jugador que usará la ficha
    public int checkboxIndex;//indice del la posición de la ficha
    public GameObject SelectionEffect;//hace referencia an círculo que es un objeto hijo de la ficha, este círculo sirve par amostrar si la ficha está siendo seleccionada
    public float timeTraslation;//timepo que demorará en moverse de un lado a otro
    // Start is called before the first frame update
  
    void Start()
    {
        SetTokenOwner(playerIndex);
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        currentPlayerIndex = gameManager.currentPlayerIndex;
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(CanMoveToken());
        }*/
    }
    int GetCurrentPlayer()
    {
        return gameManager.currentPlayerIndex;
    }
    public void SetTokenOwner(int index)//asigna la propiedades iniciales de la ficha y la crea con un color según el indice del jugador al que pertenezca 
    {
        playerIndex = index; 
        checkboxIndex = -1;//este -1 significa que aún no está en una casilla
        if (playerIndex == 0)//si el jugador tiene el indice 0 entonces la ficha es de color negro
        {
            tokenMeshColor = Color.black;//se guarda el color negro

        }
        else if (playerIndex == 1)//si el jugador tiene el indice 1 entonces la ficha es de color blanco
        {
            tokenMeshColor = Color.white;//se guarda el color blanco
        }
        gameObject.GetComponent<MeshRenderer>().material.color = tokenMeshColor;//se le añade el color guardado
        selected = false;//al principio ,ninguna ficha está seleccionada
    }
    public bool CanMoveToken()//función que retorna si se puede mover o no la ficha 
    {
        if (unplacedTokens <= 0 && GetCurrentPlayer() == playerIndex)
        {
            return true;
        }
        return false;
    }
   

    private void OnMouseOver()
    {
        Debug.Log("sobre");
        if (playerIndex==GetCurrentPlayer()&&gameManager.placedTokens[playerIndex]>=gameManager.maxTokens)
        {
            SelectionEffect.SetActive(true);
        }  
    }
    private void OnMouseExit()
    {
        SelectionEffect.SetActive(false);
    }

    public void activeToken(bool active)
    {
        gameObject.SetActive(active);
    }

    public IEnumerator Move(Vector3 newPosition)
    {
        Debug.Log("strat traslation");
        Vector3 startPosition = gameObject.transform.position;
        float currentTime = 0;
        
        //GetComponent<Collider>().enabled = false;
        while ((newPosition - gameObject.transform.position).magnitude >= 0.1f)
        {
            currentTime += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(startPosition, newPosition, currentTime/timeTraslation);
            yield return null;
        }
        //GetComponent<Collider>().enabled = true;
        gameObject.transform.position = newPosition;
        gameManager.selectingNothing();
        gameManager.finishMoveToken = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("box"))
        {
            currentCheckbox = other.GetComponent<CheckboxStatus>();
            checkboxIndex = currentCheckbox.checkboxIndex;
        }
    }

    public void DeleteToken(){
        currentCheckbox.tokenPlayerIndex = -1;
        checkboxIndex = -1;
        currentCheckbox = null;
        activeToken(false);
        gameManager.NextTurn();
        
    }


}
