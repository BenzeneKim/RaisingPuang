using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static GlobalVariables Instance; // Singleton instance

    // Your global variables
    public float Money;
    public bool alreadyClothed;

    private void Awake()
    {
        alreadyClothed = false;
        // Ensure there is only one instance of GlobalVariables
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
