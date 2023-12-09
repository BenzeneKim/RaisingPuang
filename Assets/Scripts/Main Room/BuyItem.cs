using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public GameObject BuyBtn;
    public GameObject BuyText;
    public GameObject EquipBtn;
    public GlobalVariables globalVariables;

    private void Start()
    {
        if (BuyBtn != null)
        {
            BuyBtn.SetActive(true);
        }

        if (BuyText != null)
        {
            BuyText.SetActive(true);
        }

        if (EquipBtn != null)
        {
            EquipBtn.SetActive(false);
        }
    }

    public void ToggleBuyBtn()
    {
        if (globalVariables.Money >= 5000)
        {
            if (BuyBtn != null && EquipBtn != null)
            {
                BuyBtn.SetActive(false);
                BuyText.SetActive(false);
                EquipBtn.SetActive(true);
                globalVariables.Money -= 5000;
            }
        }        
    }
}
