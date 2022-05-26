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
    Token currentToken;
    // Start is called before the first frame update
    void Start()
    {
        checkboxAvailable = true;
        tokenPlayerIndex = -1;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("token") && checkboxAvailable == true)
        {
            //tokeIndex captura el indice de la ficha entrante
            tokenPlayerIndex = other.gameObject.transform.GetComponent<Token>().playerIndex;
            checkboxAvailable = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.CompareTag("token") && checkboxAvailable == false)
        {
            tokenPlayerIndex = -1;
            checkboxAvailable = true;
        }
    }
}
