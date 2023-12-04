using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeScreen : MonoBehaviour
{
    public bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator FadeIn()
    {
        this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        while (this.gameObject.GetComponent<Image>().color.a > 0.01f)
        {

            Color _color = this.gameObject.GetComponent<Image>().color;
            this.gameObject.GetComponent<Image>().color = new Color(_color.r, _color.g, _color.b, _color.a - 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        state = true;
        this.gameObject.GetComponent<Image>().raycastTarget = false;
    }
    public IEnumerator FadeOut()
    {
        this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        this.gameObject.GetComponent<Image>().raycastTarget = true;
        while (this.gameObject.GetComponent<Image>().color.a < 0.99f)
        {

            Color _color = this.gameObject.GetComponent<Image>().color;
            this.gameObject.GetComponent<Image>().color = new Color(_color.r, _color.g, _color.b, _color.a + 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0, 1);
        state = false;
    }
}
