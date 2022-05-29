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
    public GameManager gameManager;//adquiere el gameManager que hay en la escena
    private CheckboxStatus currentCheckbox;//casilla en la que se encuentra actualmente

    void Start()
    {
        SetTokenOwner(playerIndex);//asignar el indice del jugador y guardar el color de este
        gameManager = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();
        currentPlayerIndex = gameManager.currentPlayerIndex;//
        if (gameObject.GetComponent<MeshRenderer>() != null) gameObject.GetComponent<MeshRenderer>().material.color = tokenMeshColor;//cumprueba si el objeto tiene el elemento MeshRenderer par aluego colocar el color asignado
    }
    // Update is called once per frame
    public int GetCurrentPlayer()
    {
        return gameManager.currentPlayerIndex;
    }

    private void OnMouseOver()
    {    //si es el turno del jugaodr actual , si ya se pusieron todas las fichas en el tablero y si no se formó un molino
        if (playerIndex == GetCurrentPlayer() && gameManager.placedTokens[playerIndex] == gameManager.maxTokens && !gameManager.makeMill)
            SelectionEffect.SetActive(true); //entonces activará el efecto del círculo al pasar el cursor sobre la ficha

    }
    private void OnMouseExit()
    {
        SelectionEffect.SetActive(false);//desactuva el efecto del círculo cuando quitamos el cursor de la ficha
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
    }
    public IEnumerator Move(Vector3 newPosition)
    {
        Vector3 startPosition = gameObject.transform.position;
        float currentTime = 0;

        while ((newPosition - gameObject.transform.position).magnitude >= 0.1f)
        {
            currentTime += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp(startPosition, newPosition, currentTime/timeTraslation);
            yield return null;
        }
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
