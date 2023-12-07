using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public int Money;

    private void Start()
    {
        Money = 0;
        Debug.Log(Money);
    }
}