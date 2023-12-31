using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    [SerializeField] private GameObject _BuyBtn;
    //[SerializeField] private GameObject _BuyText;
    [SerializeField] private GameObject _EquipBtn;
    [SerializeField] private GameObject _EquippedBtn;
    [SerializeField] private GameObject _Item;
    [SerializeField] private int index;

    private void Start()
    {
        _BuyBtn?.SetActive(true);
        _EquipBtn?.SetActive(false);
        _EquippedBtn?.SetActive(false);
        if (_Item != null) _Item?.SetActive(false);
    }

    public void ToggleBuyBtn()
    {
        if (GameManager.instance.Money >= 5000)
        {
            if (_BuyBtn != null && _EquipBtn != null)
            {
                _BuyBtn.SetActive(false);
                //_BuyText.SetActive(false);
                _EquipBtn.SetActive(true);
                GameManager.instance.Money -= 5000;
                GameManager.instance.State += (int)Mathf.Pow(3, index);
            }
        }
    }

    public void HaveItem(bool clothed = false)
    {
        switch (clothed)
        {
            case true:
                _BuyBtn?.SetActive(false);
                _EquipBtn?.SetActive(true);
                _EquipBtn?.GetComponent<EquipClothe>()?.ToggleEquipBtn(true);
                _EquipBtn?.GetComponent<EquipItem>()?.ToggleEquipBtn(true);
                break;
            case false:
                _BuyBtn?.SetActive(false);
                _EquipBtn?.SetActive(true);
                _EquippedBtn?.SetActive(false);
                break;

        }
    }
}
