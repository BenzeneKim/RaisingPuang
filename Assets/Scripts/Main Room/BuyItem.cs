using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    public GlobalVariables globalVariables;
    [SerializeField] private GameObject _BuyBtn;
    //[SerializeField] private GameObject _BuyText;
    [SerializeField] private GameObject _EquipBtn;
    [SerializeField] private GameObject _EquippedBtn;
    [SerializeField] private GameObject _Item;
    private void Start()
    {
        _BuyBtn?.SetActive(true);
        //_BuyText?.SetActive(true);
        _EquipBtn?.SetActive(false);
        _EquippedBtn?.SetActive(false);
        _EquippedBtn?.SetActive(false);
        _Item?.SetActive(false);
    }

    public void ToggleBuyBtn()
    {
        if (globalVariables.Money >= 5000)
        {
            if (_BuyBtn != null && _EquipBtn != null)
            {
                _BuyBtn.SetActive(false);
                //_BuyText.SetActive(false);
                _EquipBtn.SetActive(true);
                globalVariables.Money -= 5000;
            }
        }        
    }
}
