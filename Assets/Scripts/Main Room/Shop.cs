using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopBtn; 

    private void Start()
    {
        if (ShopBtn != null)
        {
            ShopBtn.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        ToggleShop();
    }

    private void ToggleShop()
    {
        if (ShopBtn != null)
        {
            ShopBtn.SetActive(!ShopBtn.activeSelf);
        }
    }
}
