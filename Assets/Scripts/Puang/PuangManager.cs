using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuangManager : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(InputManager());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator InputManager()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,5), ForceMode2D.Impulse);
            }
            yield return new WaitForSeconds(float.MinValue);
        }
    }
}
