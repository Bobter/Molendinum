using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentPlayerIndex;
    public bool twoPlayers=false;
    public float maxDistance;

    public GameObject box;
    public GameObject token;
    public bool TokeIsMoving=false;
    int[] unplacedTokens = { 9, 9 };
    int[] totalTokens = { 9, 9 };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray direction = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(direction.origin, direction.direction * maxDistance, Color.cyan);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            SelecObject();
        }
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
            if (hit.transform.CompareTag("token"))
            {   
                if (hit.transform.GetComponent<Token>().playerIndex==currentPlayerIndex)
                {
                    token = hit.transform.gameObject;
                }
                Debug.Log("ficha");
            } else if (hit.transform.CompareTag("box") && token != null)
            {
                Debug.Log("mover a");
                StartCoroutine(token.GetComponent<Token>().Move(hit.transform.position));
                token = null;
                box = null;

            }
            else
            {
                Debug.Log("nada");
                token = null;
                box = null;
            }
        }
        else
        {
            Debug.Log("nada");
            token = null;
            box = null;
        }

    }
}
