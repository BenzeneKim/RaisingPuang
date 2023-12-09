using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public SpriteRenderer[] tiles;

    private SpriteRenderer temp;
    private Coroutine scroller;
    private bool updatePosition=false;


    
    public void StartScroll()
    {
        updatePosition=true;
        scroller = StartCoroutine(ScrollPlatforms());
    }
    public void StopScroll()
    {
        updatePosition=false;
        if (scroller != null) StopCoroutine(scroller);
    }

    private IEnumerator ScrollPlatforms()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
        }
    }
    void Start()
    {
        temp = tiles[0];
    }
    void Update()
    {
        if (updatePosition)
        {

            for (int i = 0; i < tiles.Length; i++)
            {
                if (-15 >= tiles[i].transform.position.x)
                {
                    for (int j = 0; j < tiles.Length; j++)
                    {
                        if (temp.transform.position.x < tiles[j].transform.position.x)
                            temp = tiles[j];
                    }

                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 5, -4.5f);
                }
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.speed);
            }
        }
    }
}
