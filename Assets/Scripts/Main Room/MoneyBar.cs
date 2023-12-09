using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyBar : MonoBehaviour
{
    public static TextMeshProUGUI Txt; // Use TextMeshProUGUI for TextMeshPro text

    // Assuming max is always 10000, you can adjust this based on your needs
    private float max = 10000;

    private void Start()
    {
        Txt = GetComponentInChildren<TextMeshProUGUI>();
        Txt.text = "0";
    }

    private void UpdateBar(int money)
    {
        float percentage = money / max;
        Txt.text = $"$ {GameManager.Instance.Money}";
    }

    private void Update()
    {
        UpdateBar(GameManager.Instance.Money);
    }

    // This method is called whenever you want to update the bar with a specific value
    public void SetMoney(int money)
    {
        GameManager.Instance.Money = money;
        UpdateBar(money);
    }
}
