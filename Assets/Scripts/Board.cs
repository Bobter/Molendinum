using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public CheckboxStatus[] Checkbox = new CheckboxStatus[24];
    public Vector3[] Coordinates = new Vector3[24];

    // Start is called before the first frame update
    void Start()
    {
        CheckboxAssignation();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void CheckboxAssignation()
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
