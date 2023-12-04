using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PuangState
{
    IDLE,
    RUNNING,
    JUMP,
    DOUBLE_JUMP,
    DIE,
}

public class PuangManager : MonoBehaviour
{
    public Rigidbody2D rb;
    private PuangState _state = PuangState.IDLE;
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
        while (_state == PuangState.IDLE) yield return new WaitForSeconds(0.01f);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                switch (_state)
                {
                    case PuangState.JUMP:
                        _state = PuangState.DOUBLE_JUMP;
                        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                        break;
                    case PuangState.RUNNING:
                        _state = PuangState.JUMP;
                        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                        break;
                }
            }
            yield return new WaitForSeconds(float.MinValue);
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_state == PuangState.IDLE) return;
        if (collision.gameObject.tag == "Platform") _state = PuangState.RUNNING;
        else if (collision.gameObject.tag == "Obstacle") _state = PuangState.DIE;

    }
}
