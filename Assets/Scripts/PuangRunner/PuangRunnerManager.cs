using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PuangRunnerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PuangManager puang;
    public UIManager uiManager;
    public PlatformManager platformManager;
    public ObstacleManager obstacleManager;
    public CanManager canManager;
    public BackgroundController backgroundController;

    public int speed;
    public static PuangRunnerManager instance { get; set; }
    private int _score=0;
    private int _levelUpCounter = 0;
    private int _destinationScore = 50;
    private double _startTime = 0;
    private double _timerOffset = -500;
    public double spentTime { get { return _timerOffset + Time.timeAsDouble - _startTime; } }
    [SerializeField] private AudioSource _levelupSound;
    void Start()
    {
        StartCoroutine(ReadyGame());
    }

    // Update is called once per frame
    void Update()
    {
        if (spentTime > 60) Succeed();
    }

    private void Succeed()
    {
        puang.Succeed();
        this.gameObject.GetComponent<AudioSource>().Stop();
        platformManager.StopScroll();
        backgroundController.StopScroll();
        obstacleManager.StopGenerate();
        canManager.StopGenerate();
        uiManager.ShowEndWindow(_score);
        GameManager.instance.Can += _score;
        GameManager.instance.Save();
    }

    public void Die()
    {
        this.gameObject.GetComponent<AudioSource>().Stop();
        platformManager.StopScroll();
        backgroundController.StopScroll();
        obstacleManager.StopGenerate();
        canManager.StopGenerate();
        uiManager.ShowEndWindow(_score);
        GameManager.instance.Can += _score;
        GameManager.instance.Save();
    }

    public void End()
    {
        StartCoroutine(EndGame());
    }
    public void IncScore()
    {
        _score++;
        _levelUpCounter++;
        if (_levelUpCounter == _destinationScore && speed < 20)
        {
            _levelUpCounter = 0;
            speed++;
            _destinationScore += 30;
            _levelupSound.Play();

        }
        uiManager.UpdateScore(_score);
    }

    public PuangRunnerManager()
    {
        if (instance && !instance.Equals(this))
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void Pause()
    {
        platformManager.StopScroll();
        backgroundController.StopScroll();
        obstacleManager.StopGenerate();
        canManager.StopGenerate();
        uiManager.ShowPauseWindow();
        puang.PausePuang();
        _timerOffset = spentTime;
    }

    public void Restart()
    {
        ///todo : reset code
        ///
        obstacleManager.Init();
        canManager.Init();
        uiManager.HidePauseWindow();
        uiManager.HideEndWindow();
        _score = 0;
        _levelUpCounter = 0;
        speed = 10;
        StartCoroutine(ReadyGame());
    }
    public void Resume()
    {

        uiManager.HideEndWindow();
        uiManager.HidePauseWindow();
        StartCoroutine(ResumeGame());
    }

    IEnumerator ReadyGame()
    {
        _timerOffset = -500;
        this.gameObject.GetComponent<AudioSource>().Play();
        puang.Init();
        StartCoroutine (uiManager.fadeScreen.FadeIn());
        yield return null;
        while (!uiManager.fadeScreen.state) yield return new WaitForSeconds(0.01f);
        StartCoroutine(uiManager.Countdown());
        yield return null;
        while (!uiManager.countDownDone) yield return new WaitForSeconds(0.01f);
        _startTime = Time.timeAsDouble;
        _timerOffset = 0;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        puang.Run();
        obstacleManager.Init();
        canManager.Init();
        platformManager.StartScroll();
        backgroundController.StartScroll();
        canManager.StartGenerate();
        yield return new WaitForSeconds(1f);
        obstacleManager.StartGenerate();
        yield return null;
    }


    IEnumerator ResumeGame()
    {
        StartCoroutine(uiManager.Countdown());
        yield return null;
        while (!uiManager.countDownDone) yield return new WaitForSeconds(0.01f);
        _startTime = Time.timeAsDouble;
        puang.ResumePuang();
        platformManager.StartScroll();
        backgroundController.StartScroll();
        obstacleManager.StartGenerate();
        canManager.StartGenerate();
    }


    IEnumerator EndGame()
    {
        uiManager.fadeScreen.FadeOut();
        SceneManager.LoadScene(0);
        yield return null;
    }

}
