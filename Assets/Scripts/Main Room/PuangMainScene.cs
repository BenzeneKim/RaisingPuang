using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuangMainScene : MonoBehaviour
{

    public GlobalVariables globalVariables;

    private void OnMouseDown()
    {
        globalVariables.Money++;
        Debug.Log(globalVariables.Money);
    }
}
