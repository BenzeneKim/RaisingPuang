using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuangMainScene : MonoBehaviour
{

    public GlobalVariables globalVariables;

    private void OnMouseDown()
    {
        if (globalVariables.Money < 10000)
            globalVariables.Money+=1000;
    }
}