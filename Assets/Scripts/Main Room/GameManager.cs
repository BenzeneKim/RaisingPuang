using System;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    // Your global variables
    public int Money;
    public int Can;
    public int ClothState = 0;
    public int State = 0;
    public int PuangAge = 1;
    public int[] LevelLimit = new int[10];
    [SerializeField] private List<BuyItem> BuyButtons = new List<BuyItem>();
    [SerializeField] private Button _connectButton;
    [SerializeField] private Button _refreshButton;
    [SerializeField] private TMP_Dropdown _portNames;


    private void Awake()
    {
        // Ensure there is only one instance of GlobalVariables
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        Money = PlayerPrefs.GetInt("Money");
        Can = PlayerPrefs.GetInt("Can");
        State = PlayerPrefs.GetInt("State");                  // nothing = 0, jaket = 1, hoodie = 2, Raincoat = 3, Banana = 4, Santa = 5
        PuangAge = PlayerPrefs.GetInt("PuangAge") == 0 ? 1 : PlayerPrefs.GetInt("PuangAge");                  // nothing = 0, jaket = 1, hoodie = 2, Raincoat = 3, Banana = 4, Santa = 5
        BuyButtons.Add(GameObject.Find("JacketBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("HoodieBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("RaincoatBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("BananaBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("SantaBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("WoodenWheelBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("ScratBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("WoodenTowerBuyButton").GetComponent<BuyItem>());
        BuyButtons.Add(GameObject.Find("WoodenShelfBuyButton").GetComponent<BuyItem>());
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
            _temp.Add((int)state / (int)(Mathf.Pow(3,8-i)));
            state = state - ((int)Mathf.Pow(3, 8 - i)*_temp[i]);
        }
        //Debug.Log($"{_temp[0]}{_temp[1]}{_temp[2]}{_temp[3]}{_temp[4]}{_temp[5]}{_temp[6]}{_temp[7]}{_temp[8]}");
        _temp.Reverse();
        return _temp.ToArray();
    }
    
    public void Save()
    {
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("Can", Can);
        PlayerPrefs.SetInt("State", State);
        PlayerPrefs.SetInt("PuangAge", PuangAge);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Money = 0;
            Can = 0;
            State = 0;
            PuangAge = 1;
        }
    }

    public void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Money", Money);
        PlayerPrefs.SetInt("Can", Can);
        PlayerPrefs.SetInt("State", State);
        PlayerPrefs.SetInt("PuangAge", PuangAge);
    }
    public void Quit()
    {

        Application.Quit();
    }

    public void Refresh()
    {
        _portNames.ClearOptions();
        _portNames.AddOptions(PedalConnector.instance.GetPortList());
    }

    public void Connect()
    {
        PedalConnector.instance.Connect(_portNames.captionText.text);
    }
}
