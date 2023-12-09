using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject[] bgImg;
    [SerializeField] private GameObject[] cloud;
    private bool updatePosition;
    public void StartScroll()
    {
        updatePosition = true;
    }
    public void StopScroll()
    {
        updatePosition = false;
    }

    private void Update()
    {
        if (updatePosition)
        {
            for (int i = 0; i < bgImg.Length; i++)
            {
                bgImg[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * PuangRunnerManager.instance.speed * 0.2f);
                if (bgImg[i].transform.position.x <= -19.15f) bgImg[i].transform.position = new Vector2(19.15f, 0.55f);
            }
            for (int i = 0; i < cloud.Length; i++)
            {

                cloud[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * PuangRunnerManager.instance.speed * 0.05f);
                if (cloud[i].transform.position.x <= -12) cloud[i].transform.position = new Vector2(12f, Random.RandomRange(3,5));
            }
        }
    }
    
}
