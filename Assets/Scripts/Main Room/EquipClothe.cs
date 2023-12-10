using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipClothe : MonoBehaviour
{
    public GameObject EquipBtn;
    public GameObject EquippedBtn;
    public Sprite Item;
    public GameObject Puang;
    [SerializeField] private int index;
    private void Start()
    {
        Puang.SetActive(true);
    }

    public void ToggleEquipBtn(bool init = false)
    {
        if (GameManager.instance.ClothState != 0) return;
        EquipBtn.SetActive(false);
        EquippedBtn.SetActive(true);
        Puang.GetComponent<SpriteRenderer>().sprite = Item;
        if (!init) GameManager.instance.State += (int)Mathf.Pow(3, index);
        GameManager.instance.ClothState = index + 1;
    }

    public void ToggleEquippedBtn(bool init = false)
    {
        if (GameManager.instance.ClothState == 0) return;
        EquipBtn.SetActive(true);
        EquippedBtn.SetActive(false);
        Puang.GetComponent<SpriteRenderer>().sprite = Item;
        if (!init) GameManager.instance.State -= (int)Mathf.Pow(3, index);
        GameManager.instance.ClothState = 0;
    }
}

