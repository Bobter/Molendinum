using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tokens : MonoBehaviour
{
    Color playerColor;
    //MeshRenderer meshColor;

    public int playerIndex;//indice del jugador que usará la ficha
    public int tokenIndex;//indice del la posición de la ficha
    public GameObject SelectionEfect;//efecto que se activará al seleccionar ficha
    public bool isSelected;//está o no está seleccionado la ficha la ficha 
    public bool isActivate;//está o no está activado la ficha 1
    
    // Start is called before the first frame update
    void Start()
    {
        Desactive();
        SelectionEfect.SetActive(false);
        isSelected = false;
        if (playerIndex == 1)
        {
            playerColor = Color.black;
        } else if (playerIndex == 2)
        {
            playerColor = Color.white;
        }
        gameObject.GetComponent<MeshRenderer>().material.color = playerColor;
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
            Desactive();
        }
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
    public void Desactive()//estado inical de la ficha 
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
