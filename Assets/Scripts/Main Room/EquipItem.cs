using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public GameObject targetButton;
    public GameObject Item;
    [SerializeField] private int index;
    private void Awake()
    {
        if (Item != null)
        {
            Item.SetActive(false);
        }
    }

    public void ToggleEquipBtn(bool init = false)
    {
        if (targetButton != null)
        {
            this.gameObject.SetActive(false);
            targetButton.SetActive(true);
            if (Item.active)
            {
                if (!init) GameManager.instance.State -= (int)Mathf.Pow(3, index);
            }
            else
            {
                if (!init) GameManager.instance.State += (int)Mathf.Pow(3, index);
            }
            Item.SetActive(!Item.activeSelf);
        }
    }
}

