using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class JellyManager: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> _jellies = new List<GameObject>(35);
    private GameObject _activedObstacle;
    [SerializeField]
    private ObstacleManager _obstacleManager;
    
    [SerializeField]
    private float _period;

    [SerializeField]
    private float _parabolaA;
    [SerializeField]
    private float _parabolaB;
    [SerializeField]
    private float _defaultHeight;
    private bool updatePosition = false;
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (updatePosition)
        {

            foreach (GameObject activatedJelly in _jellies)
            {
                activatedJelly.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.speed, 0);
                if (activatedJelly.transform.position.x < -12)
                {
                    activatedJelly.SetActive(false);
                }
            }
        }
    }
    public void Init()
    {

        foreach (GameObject obj in _jellies)
            obj.SetActive(false);
    }

    public void StartGenerate()
    {
        updatePosition = true;
        StartCoroutine(Generator());
    }
    public void StopGenerate()
    {
        updatePosition=false;
        StopAllCoroutines();
    }

    IEnumerator Generator()
    {
        while (true)
        {
            foreach(GameObject unactivatedJelly in _jellies)
            {
                if(unactivatedJelly.active == false)
                {
                    unactivatedJelly.SetActive(true);
                    if (_obstacleManager.isObstacleActivated)
                    {
                        float distance = _obstacleManager.activatedObstaclePoint.x - 12;
                        float yValue = -_parabolaA * distance * distance + _parabolaB + _obstacleManager.activatedObstaclePoint.y;
                        unactivatedJelly.transform.position = (yValue < _defaultHeight) ? new Vector2(12, _defaultHeight) : new Vector2(12, yValue);
                    }
                    else unactivatedJelly.transform.position = new Vector2(12, _defaultHeight);
                    break;
                }

            }
            yield return new WaitForSeconds(_period);
        }
    }

}
