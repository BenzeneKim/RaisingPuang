using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public void TogglePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(!Panel.activeSelf);
        }
    }

    private void Start()
    {
        Panel.SetActive(false);
    }
}
