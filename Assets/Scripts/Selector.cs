using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    // Start is called before the first frame update
    

    public GameObject SelectObject(int currentPlayerIndex,float maxDistance)
    {
        RaycastHit hit;
        Ray mouseDirection = Camera.main.ScreenPointToRay(Input.mousePosition);
        int deleteTokenIndex = (currentPlayerIndex + 1) % 2;
        if (Physics.Raycast(mouseDirection.origin, mouseDirection.direction, out hit, maxDistance))//si el rayo choca con algo
        {
            return hit.transform.gameObject;
        }
        return null;
    }
}
