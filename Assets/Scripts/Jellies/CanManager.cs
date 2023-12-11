using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CanManager: MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> _can = new List<GameObject>(0);
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
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _can.Add(gameObject.transform.GetChild(i).gameObject);
        }
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (updatePosition)
        {

            foreach (GameObject activatedCan in _can)
            {
                activatedCan.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * PuangRunnerManager.instance.speed, 0);
                if (activatedCan.transform.position.x < -12)
                {
                    activatedCan.SetActive(false);
                }
            }
        }
    }
    public void Init()
    {

        foreach (GameObject obj in _can)
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
            foreach(GameObject unactivatedCan in _can)
            {
                if(unactivatedCan.active == false)
                {
                    unactivatedCan.SetActive(true);
                    if (_obstacleManager.isObstacleActivated)
                    {
                        float distance = _obstacleManager.activatedObstaclePoint.x - 12;
                        float yValue = -_parabolaA * distance * distance + _parabolaB + _obstacleManager.activatedObstaclePoint.y;
                        unactivatedCan.transform.position = (yValue < _defaultHeight) ? new Vector2(12, _defaultHeight) : new Vector2(12, yValue);
                    }
                    else unactivatedCan.transform.position = new Vector2(12, _defaultHeight);
                    break;
                }

            }
            yield return new WaitForSeconds(_period);
        }
    }

}
