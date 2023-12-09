using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance

    // Your global variables
    public int Money;
    public int Jelly;
    public int ClothState = 0;
    public int State = 0;
    public int PuangAge = 1;
    public int[] LevelLimit = new int[10];
    [SerializeField] private List<BuyItem> BuyButtons;
    
    private void Awake()
    {
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

        Money = PlayerPrefs.GetInt("Money");
        Jelly = PlayerPrefs.GetInt("Jelly");
        State = PlayerPrefs.GetInt("State");                  // nothing = 0, jaket = 1, hoodie = 2, Raincoat = 3, Banana = 4, Santa = 5
        PuangAge = PlayerPrefs.GetInt("PuangAge");                  // nothing = 0, jaket = 1, hoodie = 2, Raincoat = 3, Banana = 4, Santa = 5

        int[] StateArray = Parse(State);
        for(int i = 0; i < 9; i++)
        {
            switch (StateArray[i])
            {
                case 1:
                    BuyButtons[i].HaveItem();
                    break;
                case 2:
                    BuyButtons[i].HaveItem(true);
                    break;
            }
        }
    }

    private int[] Parse(int state)
    {
        List<int> _temp = new List<int>();
        for(int i = 0; i < 9; i++)
        {
            _temp.Add(state % 3);
            state /= 3;
        }
        return _temp.ToArray();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("Jelly", Jelly);
        PlayerPrefs.SetInt("State", State);
        PlayerPrefs.SetInt("PuangAge", PuangAge);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Money = 0;
            Jelly = 0;
            State = 0;
            PuangAge = 1;
        }
    }
}
