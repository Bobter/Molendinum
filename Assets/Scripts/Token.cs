using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{   //varaibles privadas
    Color tokenMeshColor;//guarda el color de la ficha 
    bool isSelected;//booleano que indica si la ficha está o no seleccionada
    //variables públicas
    public int unplacedTokens;//variables extraida del manager que nos muestra cuantas fichas faltan colocar en el tablero
    public int currentPlayerIndex;//indice del jugador del que es su turno
    public int playerIndex;//indice del jugador que usará la ficha
    public int placeIndex;//indice del la posición de la ficha
    public GameObject SelectionEffect;//hace referencia an círculo que es un objeto hijo de la ficha, este círculo sirve par amostrar si la ficha está siendo seleccionada

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
    private void SetTokenOwner()//asigna la propiedades iniciales de la ficha y la crea con un color según el indice del jugador al que pertenezca 
    {
        placeIndex = -1;//este -1 significa que aún no está en una casilla
        if (playerIndex == 1)//si el jugador tiene el indice 1 entonces la ficha es de color negro
        {
            tokenMeshColor = Color.black;//se guarda el color negro

        }
        else if (playerIndex == 2)//si el jugador tiene el indice 2 entonces la ficha es de color blanco
        {
            tokenMeshColor = Color.white;//se guarda el color blanco
        }
        gameObject.GetComponent<MeshRenderer>().material.color = tokenMeshColor;//se le añade el color guardado
        isSelected = false;//al principio ,ninguna ficha está seleccionada
    }
    public bool CanMoveToken()//función que retorna si se puede mover o no la ficha 
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
