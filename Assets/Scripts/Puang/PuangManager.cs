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

    [SerializeField]
    private Sprite _runA;
    [SerializeField]
    private Sprite _runB;
    [SerializeField]
    private Sprite _runC;
    [SerializeField]
    private Sprite _runD;
    [SerializeField]
    private Sprite _jump;
    [SerializeField]
    private Sprite _die;

    private Coroutine runRefresh;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case PuangState.IDLE:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _runD;
                break;
            case PuangState.RUNNING:
                if (runRefresh == null) runRefresh = StartCoroutine(RunRefresher());
                break;
            case PuangState.JUMP:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _jump;
                break;
            case PuangState.DOUBLE_JUMP:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _jump;
                break;
            case PuangState.DIE:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = _die;
                break;

        }
    }

    private IEnumerator RunRefresher()
    {
        int imageIndex = 0;
        while(_state == PuangState.RUNNING)
        {

            switch (imageIndex)
            {
                case 0:
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = _runA;
                    imageIndex = 1;
                    break;
                case 1:
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = _runB;
                    imageIndex = 2;
                    break;
                case 2:
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = _runC;
                    imageIndex = 3;
                    break;
                case 3:
                    this.gameObject.GetComponent<SpriteRenderer>().sprite = _runD;
                    imageIndex = 0;
                    break;

                    
            }
            yield return new WaitForSeconds(0.15f * 10 / GameManager.instance.speed);
        }

            
        runRefresh = null;
    }


    public void Init()
    {
        _state = PuangState.IDLE;
        this.gameObject.transform.position = new Vector2(-6, 2);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        rb.useAutoMass = true;
        _inputManager = StartCoroutine(InputManager());
    }

    public void Run()
    {
        _state = PuangState.RUNNING;

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
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
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
        else if (collision.gameObject.tag == "Obstacle") Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Jelly")
        {
            GameManager.instance.IncScore();
            collision.gameObject.SetActive(false);
        }

    }

    private void Die()
    {

        _state = PuangState.DIE;
        GameManager.instance.Die();
        _pausedVelocity = rb.velocity;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        StopCoroutine(_inputManager);
    }
}
