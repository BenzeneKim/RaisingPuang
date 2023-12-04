using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private List<GameObject> _obstacles = new List<GameObject>(5);
    private GameObject _activedObstacle;
    
    [SerializeField]
    private int speed;

    void Start()
    {
        foreach (GameObject obj in _obstacles)
            obj.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGenerate()
    {
        StartCoroutine(Generator());
        StartCoroutine(UpdatePosition());
    }
    public void StopGenerate()
    {
        StopAllCoroutines();
    }

    IEnumerator Generator()
    {
        while (true)
        {
            if (_activedObstacle == null)
            {
                if (Random.Range(0, 10) < 5f)
                {
                    yield return new WaitForSeconds(0.1f);
                }
                else
                {
                    int ind = Random.Range(0, _obstacles.Count);
                    _activedObstacle = _obstacles[ind];
                    _activedObstacle.transform.position = new Vector2(15, -1);
                    _activedObstacle.SetActive(true);
                    Debug.Log($"{ind} activated");
                    yield return new WaitForSeconds(0.1f);

                }

            }
            else
                yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator UpdatePosition()
    {
        while (true) 
        {
            if (_activedObstacle != null)
            { 
                _activedObstacle.transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed, 0);
                if (_activedObstacle.transform.position.x < -15)
                {
                    _activedObstacle.SetActive(false);
                    _activedObstacle = null;
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
}
