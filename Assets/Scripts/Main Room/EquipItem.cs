using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public GameObject targetButton;
    public GameObject Item;
    [SerializeField] GameManager globalVariables;
    [SerializeField] int index;
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
            if(Item.active)
                globalVariables.State -= (int)Mathf.Pow(3, index);
            else
                globalVariables.State += (int)Mathf.Pow(3, index);
            Item.SetActive(!Item.activeSelf);
        }
    }
}

