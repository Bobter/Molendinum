using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{   //varaibles privadas
    Color tokenMeshColor;//guarda el color de la ficha 
    bool isSelected;//booleano que indica si la ficha est� o no seleccionada
    //variables p�blicas
    public int unplacedTokens;//variables extraida del manager que nos muestra cuantas fichas faltan colocar en el tablero
    public int currentPlayerIndex;//indice del jugador del que es su turno
    public int playerIndex;//indice del jugador que usar� la ficha
    public int placeIndex;//indice del la posici�n de la ficha
    public GameObject SelectionEffect;//hace referencia an c�rculo que es un objeto hijo de la ficha, este c�rculo sirve par amostrar si la ficha est� siendo seleccionada

    // Start is called before the first frame update
    void Start()
    {
        SetTokenOwner();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(CanMoveToken());
        }
    }
    private void SetTokenOwner()//asigna la propiedades iniciales de la ficha y la crea con un color seg�n el indice del jugador al que pertenezca 
    {
        placeIndex = -1;//este -1 significa que a�n no est� en una casilla
        if (playerIndex == 1)//si el jugador tiene el indice 1 entonces la ficha es de color negro
        {
            tokenMeshColor = Color.black;//se guarda el color negro

        }
        else if (playerIndex == 2)//si el jugador tiene el indice 2 entonces la ficha es de color blanco
        {
            tokenMeshColor = Color.white;//se guarda el color blanco
        }
        gameObject.GetComponent<MeshRenderer>().material.color = tokenMeshColor;//se le a�ade el color guardado
        isSelected = false;//al principio ,ninguna ficha est� seleccionada
    }
    public bool CanMoveToken()//funci�n que retorna si se puede mover o no la ficha 
    {
        if (unplacedTokens <= 0 && currentPlayerIndex == playerIndex)
        {
            return true;
        }
        return false;
    }
    private void OnMouseOver()
    {
        if (playerIndex==currentPlayerIndex)
        {
            SelectionEffect.SetActive(true);
        }  
    }
    private void OnMouseExit()
    {
        SelectionEffect.SetActive(false);
    }
}
