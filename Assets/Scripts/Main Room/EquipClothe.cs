using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipClothe : MonoBehaviour
{
    public GameObject EquipBtn;
    public GameObject EquippedBtn;
    public Sprite Item;
    public GameObject Puang;
    public GlobalVariables globalVariables;

    private void Start()
    {
        Puang.SetActive(true);
    }

    public void ToggleEquipBtn()
    {
        if (globalVariables.alreadyClothed) return;
        EquipBtn.SetActive(false);
        EquippedBtn.SetActive(true);
        Puang.GetComponent<SpriteRenderer>().sprite = Item;
        globalVariables.alreadyClothed = true;
    }

    public void ToggleEquippedBtn()
    {
        if (!globalVariables.alreadyClothed) return;
        EquipBtn.SetActive(true);
        EquippedBtn.SetActive(false);
        Puang.GetComponent<SpriteRenderer>().sprite = Item;
        globalVariables.alreadyClothed = false;
    }
}

