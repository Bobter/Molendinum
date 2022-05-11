using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour
{
    Color playerColor;//
    //MeshRenderer meshColor;

    public int playerIndex;//indice del jugador que usar� la ficha
    public int tokenIndex;//indice del la posici�n de la ficha
    public GameObject SelectionEfect;//efecto que se activar� al seleccionar ficha
    public bool isSelected;//est� o no est� seleccionado la ficha la ficha 
    public bool isActivate;//est� o no est� activado la ficha 1
    
    // Start is called before the first frame update
    void Start()
    {
        DesactiveToken();
        SelectionEfect.SetActive(false);
        SetTokenOwner();
        isSelected = false;
       
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Active();
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            DesactiveToken();
        }
    }

    private void SetTokenOwner()//asigna el color de la ficha seg�n el indice del jugador al que pertenezca 
    {
        if (playerIndex == 1)//si el jugador tiene el indice 1 entonces la ficha es de color negro
        {
            playerColor = Color.black;
        }
        else if (playerIndex == 2)//si el jugador tiene el indice 2 entonces la ficha es de color blanco
        {
            playerColor = Color.white;
        }
        gameObject.GetComponent<MeshRenderer>().material.color = playerColor;//se le a�ade el color a la ficha
    }
    public void Selected()
    {
        isSelected = true;
        SelectionEfect.SetActive(true);
    }
    public void NoSelected()
    {
        isSelected = false;
        SelectionEfect.SetActive(false);
    }
    public void Active()//se activa cuando se selecciona por primera vez la casilla 
    {
        isActivate = true;
        gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
    public void DesactiveToken()//estado inical de la ficha 
    {
        isActivate = true;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    private void OnMouseOver()
    {
        SelectionEfect.SetActive(true);
        Debug.Log("OVER");
    }
    private void OnMouseExit()
    {
        SelectionEfect.SetActive(false);
        Debug.Log("Exit");
    }

}
