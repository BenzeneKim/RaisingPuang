using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public GameObject targetButton;
    public GameObject Item;

    private void Awake()
    {
        if (Item != null)
        {
            Item.SetActive(false);
        }
    }

    public void ToggleEquipBtn()
    {
        if (targetButton != null)
        {
            this.gameObject.SetActive(false);
            targetButton.SetActive(true);
            Item.SetActive(!Item.activeSelf);
        }
    }
}

