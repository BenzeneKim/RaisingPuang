using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuangMainScene : MonoBehaviour
{
    private Coroutine ClickEffect;
    private void OnMouseDown()
    {
        this.gameObject.GetComponent<AudioSource>().Play();
        if (ClickEffect != null) StopCoroutine(ClickEffect);
        ClickEffect = StartCoroutine(ClickEffectCor());
        if (GameManager.instance.Money < 100000)
            GameManager.instance.Money+=100*GameManager.instance.PuangAge;
    }

    IEnumerator ClickEffectCor()
    {
        this.gameObject.transform.localScale = new Vector2(0.8f, 0.7f);
        this.gameObject.transform.position = new Vector2(0,-1.2f);
        yield return new WaitForSeconds(0.2f);
        this.gameObject.transform.position = new Vector2(0,-1f);
        this.gameObject.transform.localScale = new Vector2(0.75f, 0.75f);
    }
}