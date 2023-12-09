using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipClothe : MonoBehaviour
{
    public GameObject EquipBtn;
    public GameObject EquippedBtn;
    public Sprite Item;
    public GameObject Puang;
    public GameManager globalVariables;
    [SerializeField] private int index;
    private void Start()
    {
        Puang.SetActive(true);
    }

    public void ToggleEquipBtn()
    {
        if (globalVariables.ClothState != 0) return;
        EquipBtn.SetActive(false);
        EquippedBtn.SetActive(true);
        Puang.GetComponent<SpriteRenderer>().sprite = Item;
        globalVariables.State += (int)Mathf.Pow(3, index);
        globalVariables.ClothState = index + 1;
    }

    public void ToggleEquippedBtn()
    {
        if (globalVariables.ClothState == 0) return;
        EquipBtn.SetActive(true);
        EquippedBtn.SetActive(false);
        Puang.GetComponent<SpriteRenderer>().sprite = Item;
        globalVariables.State -= (int)Mathf.Pow(3, index);
        globalVariables.ClothState = 0;
    }
}

