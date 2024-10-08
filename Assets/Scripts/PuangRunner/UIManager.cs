using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public FadeScreen fadeScreen;
    public bool countDownDone = false;
    [SerializeField] private AudioSource _countdownSound;
    [SerializeField]
    private List<GameObject> _countdown = new List<GameObject>(3);
    // Start is called before the first frame update
    [SerializeField]
    private GameObject pauseWindow;
    [SerializeField]
    private GameObject endWindow;
    [SerializeField]
    private TextMeshProUGUI finalScoreTMP;
    [SerializeField]
    private TextMeshProUGUI _scoreBar;
    [SerializeField]
    private Image _timeSpent;
    void Start()
    {
        endWindow.SetActive(false);
        pauseWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _timeSpent.fillAmount = (float)PuangRunnerManager.instance.spentTime / 60;   
    }

    public void UpdateScore(int _score)
    {
        _scoreBar.text = _score.ToString();
    }
    public void ShowPauseWindow()
    {
        pauseWindow.SetActive(true);
    }
    public void HidePauseWindow()
    {
        pauseWindow.SetActive(false);
    }
    public void ShowEndWindow(int score)
    {
        finalScoreTMP.text = score.ToString();
        endWindow.SetActive(true);
    }
    public void HideEndWindow()
    {
        endWindow.SetActive(false);
    }



    public IEnumerator Countdown()
    {

        _scoreBar.text = "0";
        countDownDone = false;
        _countdownSound.Play();
        _countdown[0].active = true;
        _countdown[1].active = false;
        _countdown[2].active = false;
        yield return new WaitForSeconds(1);
        _countdownSound.Play();
        _countdown[0].active = false;
        _countdown[1].active = true;
        _countdown[2].active = false;
        yield return new WaitForSeconds(1);
        _countdownSound.Play();
        _countdown[0].active = false;
        _countdown[1].active = false;
        _countdown[2].active = true;
        yield return new WaitForSeconds(1);
        _countdown[0].active = false;
        _countdown[1].active = false;
        _countdown[2].active = false;
        countDownDone = true;
        yield return new WaitForSeconds(1);
        countDownDone = false;
    }
}
