using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject ShopBtn; // Drag your shop UI GameObject here in the Inspector

    private void Start()
    {
        // Assurez-vous que le shop est désactivé au démarrage
        if (ShopBtn != null)
        {
            ShopBtn.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        // Affiche ou masque le shop lors du clic sur l'icône de shop
        ToggleShop();
    }

    private void ToggleShop()
    {
        if (ShopBtn != null)
        {
            // Inverse l'état actuel du shop (active/désactivé)
            ShopBtn.SetActive(!ShopBtn.activeSelf);
        }
    }
}
