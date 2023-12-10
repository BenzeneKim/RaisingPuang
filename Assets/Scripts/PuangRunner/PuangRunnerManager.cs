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
    public JellyManager jellyManager;
    public BackgroundController backgroundController;

    public int speed;
    public static PuangRunnerManager instance { get; set; }
    private int _score=0;
    private int _levelUpCounter = 0;
    private int _destinationScore = 50;
    [SerializeField] private AudioSource _levelupSound;
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
        this.gameObject.GetComponent<AudioSource>().Stop();
        platformManager.StopScroll();
        backgroundController.StopScroll();
        obstacleManager.StopGenerate();
        jellyManager.StopGenerate();
        uiManager.ShowEndWindow(_score);
        GameManager.instance.Jelly += _score;
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
        this.gameObject.GetComponent<AudioSource>().Play();
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
        backgroundController.StartScroll();
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
        backgroundController.StartScroll();
        obstacleManager.StartGenerate();
        jellyManager.StartGenerate();
    }


    IEnumerator EndGame()
    {
        uiManager.fadeScreen.FadeOut();
        SceneManager.LoadScene(0);
        yield return null;
    }

}
