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
        if (EquipBtn != null)
        {
            EquipBtn.SetActive(true);
        }

        if (EquippedBtn != null)
        {
            EquippedBtn.SetActive(false);
        }

        globalVariables.alreadyClothed = false;
        Puang.SetActive(true);
    }

    public void ToggleEquipBtn()
    {
        if (globalVariables.alreadyClothed == false || EquippedBtn.activeSelf == true)
        {
                EquipBtn.SetActive(!EquipBtn.activeSelf);
                EquippedBtn.SetActive(!EquippedBtn.activeSelf);
                Puang.GetComponent<SpriteRenderer>().sprite = Item;
                globalVariables.alreadyClothed = !globalVariables.alreadyClothed;
        }
    }
}

