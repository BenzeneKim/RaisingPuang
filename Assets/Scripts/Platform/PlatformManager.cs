using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public float speed;

    private SpriteRenderer temp;
    private Coroutine scroller;

    public void StartScroll()
    {
        scroller = StartCoroutine(ScrollPlatforms());
    }
    public void StopScroll()
    {
        if (scroller != null) StopCoroutine(scroller);
    }

    private IEnumerator ScrollPlatforms()
    {
        temp = tiles[0];
        while (true)
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

                    tiles[i].transform.position = new Vector2(temp.transform.position.x + 5, -5);
                }
            }
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
