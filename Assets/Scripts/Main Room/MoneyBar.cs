using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyBar : MonoBehaviour
{
    static Image Bar;
    public static TextMeshProUGUI Txt; // Use TextMeshProUGUI for TextMeshPro text
    public GlobalVariables globalVariables;

    // Assuming max is always 10000, you can adjust this based on your needs
    private float max = 10000;

    private void Start()
    {
        Bar = GetComponent<Image>();
        Txt = GetComponentInChildren<TextMeshProUGUI>();
        Txt.text = "0";
    }

    private void UpdateBar(float money)
    {
        float percentage = money / max;
        Bar.fillAmount = percentage;
        Txt.text = money.ToString("C");
    }

    private void Update()
    {
        UpdateBar(globalVariables.Money);
    }

    // This method is called whenever you want to update the bar with a specific value
    public void SetMoney(float money)
    {
        globalVariables.Money = money;
        UpdateBar(money);
    }
}
