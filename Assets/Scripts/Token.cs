using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{   
    public int currentPlayerIndex;//indice del jugador del que es su turno
    public int playerIndex;//indice del jugador que usará la ficha
    public int checkboxIndex;//indice del la posición de la ficha
    public GameObject SelectionEffect;//hace referencia an círculo que es un objeto hijo de la ficha, este círculo sirve par amostrar si la ficha está siendo seleccionada
    public float timeTraslation;//timepo que demorará en moverse de un lado a otro
    public Color tokenMeshColor;//guarda el color de la ficha 
   
    GameManager gameManager;//adquiere el gameManager que hay en la escena
    CheckboxStatus currentCheckbox;//casilla en la que se encuentra actualmente

    void Start()
    {
        SetTokenOwner(playerIndex);//asignar el indice del jugador y guardar el color de este
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        currentPlayerIndex = gameManager.currentPlayerIndex;//
        if (gameObject.GetComponent<MeshRenderer>() != null) gameObject.GetComponent<MeshRenderer>().material.color = tokenMeshColor;//cumprueba si el objeto tiene el elemento MeshRenderer par aluego colocar el color asignado
    }

    private void OnMouseOver()
    {    //si la ficha es del jugador del turno actual , si ya se pusieron todas las fichas en el tablero y si no se formó un molino
        if (playerIndex == currentPlayerIndex && gameManager.placedTokens[playerIndex] == gameManager.maxTokens && !gameManager.makeMill)
            SelectionEffect.SetActive(true); //entonces activará el efecto del círculo al pasar el cursor sobre la ficha
    }
    private void OnMouseExit()
    {
        SelectionEffect.SetActive(false);//desactuva el efecto del círculo cuando quitamos el cursor de la ficha
    }
    public void SetTokenOwner(int index)//asigna la propiedades iniciales de la ficha y guarda un color según el indice del jugador al que pertenezca 
    {
        playerIndex = index; 
        checkboxIndex = -1;//este -1 significa que aún no está en una casilla
        if (playerIndex == 0)//si el jugador tiene el indice 0 entonces la ficha es de color negro
            tokenMeshColor = Color.black;//se guarda el color negro
        else if (playerIndex == 1)//si el jugador tiene el indice 1 entonces la ficha es de color blanco
            tokenMeshColor = Color.white;//se guarda el color blanco
    }
    public IEnumerator Move(Vector3 newPosition)
    {
        Vector3 startPosition = gameObject.transform.position;
        float time = 0;
        gameManager.movingToken = true;
        while ((newPosition - gameObject.transform.position).magnitude >= 0.1f)//si se encuentra a una distancia mayora a 0.1 unidades
        {
            time += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(startPosition, newPosition, time/timeTraslation);//se interpola la pocisión actual hacia el destino
            yield return null;//continúa en el siguiente frame
        }
        gameManager.movingToken = false;
        gameObject.transform.position = newPosition;
        gameManager.selectingNothing();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("box"))
        {
            currentCheckbox = other.GetComponent<CheckboxStatus>();
            checkboxIndex = currentCheckbox.checkboxIndex;
        }
    }
    public void Delete(){
        currentCheckbox.tokenPlayerIndex = -1;
        currentCheckbox.checkboxAvailable = true;
        currentCheckbox.currentToken = null;
        checkboxIndex = -1;
        currentCheckbox = null;
        gameObject.SetActive(false);
    }
}
