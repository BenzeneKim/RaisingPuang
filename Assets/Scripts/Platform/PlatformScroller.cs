using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public float speed;

    private SpriteRenderer temp;

    // Start is called before the first frame update
    void Start()
    {
        temp = tiles[0];
    }

    // Update is called once per frame
    void Update()
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
    }
}
