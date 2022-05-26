using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public CheckboxStatus[] Checkbox = new CheckboxStatus[24];
    public Vector3[] Coordinates = new Vector3[24];

    void Start()
    {

        //Capturamos las posiciones en un array
        for (int i = 0; i < 24; ++i)
        {
            Coordinates[i] = transform.GetChild(i).gameObject.transform.position;
            Checkbox[i] = transform.GetChild(i).GetComponent<CheckboxStatus>();
            Checkbox[i].checkboxIndex = i;
        }
    }
}
