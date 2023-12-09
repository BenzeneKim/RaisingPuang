using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuangMainScene : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.Instance.Money < 100000)
            GameManager.Instance.Money+=100*GameManager.Instance.PuangAge;
    }
}