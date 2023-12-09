using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public GameObject EquipBtn;
    public GameObject EquippedBtn;
    public GameObject Item;

    private void Awake()
    {
        if (EquipBtn != null)
        {
            EquipBtn.SetActive(false);
        }

        if (EquippedBtn != null)
        {
            EquippedBtn.SetActive(false);
        }

        if (Item != null)
        {
            Item.SetActive(false);
        }
    }

    public void ToggleEquipBtn()
    {
        if (EquipBtn != null && EquippedBtn != null)
        {
            EquipBtn.SetActive(!EquipBtn.activeSelf);
            EquippedBtn.SetActive(!EquippedBtn.activeSelf);
            Item.SetActive(!Item.activeSelf);
        }
    }
}

