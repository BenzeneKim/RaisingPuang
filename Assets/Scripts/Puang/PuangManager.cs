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
    [SerializeField]
    private int _jumpPower = 5;
    
    private PuangState _state = PuangState.IDLE;
    private PuangState _pausedState;
    private Vector2 _pausedVelocity;
    private Coroutine _inputManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init()
    {
        _state = PuangState.RUNNING;
        this.gameObject.transform.position = new Vector2(-6, 2);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.useAutoMass = true;
        _inputManager = StartCoroutine(InputManager());
    }

    public void PausePuang()
    {
        _pausedState = _state;
        _state = PuangState.IDLE;
        _pausedVelocity = rb.velocity;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        StopCoroutine(_inputManager);
    }

    public void ResumePuang()
    {
        _state = _pausedState;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.useAutoMass = true;
        rb.velocity = _pausedVelocity;
        _inputManager = StartCoroutine(InputManager());
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
                        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
                        break;
                    case PuangState.RUNNING:
                        _state = PuangState.JUMP;
                        this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, _jumpPower), ForceMode2D.Impulse);
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
