using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    RaycastHit hit;
    Ray mouseDirection;
    public GameObject SelectObject(int currentPlayerIndex)//retornará el objeto seleccionado por el raycast
    {
        mouseDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
        int deleteTokenIndex = (currentPlayerIndex + 1) % 2;
        if (Physics.Raycast(mouseDirection.origin, mouseDirection.direction, out hit, 1000))//si el rayo choca con algo
        {
            return hit.transform.gameObject;
        }
        return null;
    }
}
