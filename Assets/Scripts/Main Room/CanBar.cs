using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanBar : MonoBehaviour
{
    public TextMeshProUGUI Txt; // Use TextMeshProUGUI for TextMeshPro text
    public TextMeshProUGUI Txt2; // Use TextMeshProUGUI for TextMeshPro text
  
    // Assuming max is always 10000, you can adjust this based on your needs
    private float max = 10000;

    
    private void UpdateBar()
    {
        Txt.text = $"{GameManager.Instance.Jelly} / {GameManager.Instance.LevelLimit[GameManager.Instance.PuangAge-1]}";
        Txt2.text = $"{GameManager.Instance.PuangAge}00$ / click";
        if(GameManager.Instance.Jelly > GameManager.Instance.LevelLimit[GameManager.Instance.PuangAge - 1])
        {
            GameManager.Instance.Jelly -= GameManager.Instance.LevelLimit[GameManager.Instance.PuangAge - 1];
            GameManager.Instance.PuangAge++;
        }
    }

    private void Update()
    {
        UpdateBar();
    }

}
