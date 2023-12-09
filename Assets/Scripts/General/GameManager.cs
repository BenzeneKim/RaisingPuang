using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PuangManager puang;
    public UIManager uiManager;
    public PlatformManager platformManager;
    public ObstacleManager obstacleManager;
    public JellyManager jellyManager;

    public int speed;
    public static GameManager instance { get; set; }
    private int _score=0;
    private int _levelUpCounter = 0;
    private int _destinationScore = 50;
    void Start()
    {
        StartCoroutine(ReadyGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        platformManager.StopScroll();
        obstacleManager.StopGenerate();
        jellyManager.StopGenerate();
        uiManager.ShowEndWindow(_score);
    }

    public void End()
    {
        StartCoroutine(EndGame());
    }
    public void IncScore()
    {
        _score++;
        _levelUpCounter++;
        if(_levelUpCounter == _destinationScore && speed < 20)
        {
            _levelUpCounter = 0;
            speed++;
            _destinationScore += 30;
            uiManager.LevelUp();
        }
        uiManager.UpdateCanState((float)_levelUpCounter / (float)_destinationScore);
    }

    public GameManager()
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
        obstacleManager.StopGenerate();
        jellyManager.StopGenerate();
        uiManager.ShowPauseWindow();
        puang.PausePuang();
    }

    public void Restart()
    {
        ///todo : reset code
        ///
        obstacleManager.Init();
        jellyManager.Init();
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
        uiManager.ResetCanStae();
        puang.Init();
        StartCoroutine (uiManager.fadeScreen.FadeIn());
        yield return null;
        while (!uiManager.fadeScreen.state) yield return new WaitForSeconds(0.01f);
        StartCoroutine(uiManager.Countdown());
        yield return null;
        while (!uiManager.countDownDone) yield return new WaitForSeconds(0.01f);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        puang.Run();
        obstacleManager.Init();
        jellyManager.Init();
        platformManager.StartScroll();
        jellyManager.StartGenerate();
        yield return new WaitForSeconds(1f);
        obstacleManager.StartGenerate();
        yield return null;
    }


    IEnumerator ResumeGame()
    {
        StartCoroutine(uiManager.Countdown());
        yield return null;
        while (!uiManager.countDownDone) yield return new WaitForSeconds(0.01f);
        puang.ResumePuang();
        platformManager.StartScroll();
        obstacleManager.StartGenerate();
        jellyManager.StartGenerate();
    }


    IEnumerator EndGame()
    {
        uiManager.fadeScreen.FadeOut();
        yield return null;
    }

}
