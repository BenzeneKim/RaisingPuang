using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PuangManager puang;
    public UIManager uiManager;
    public PlatformManager platformManager;
    void Start()
    {
        StartCoroutine(ReadyGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {


    }

    public void Pause()
    {
        platformManager.StopScroll();
        uiManager.ShowPauseWindow();
        puang.PausePuang();
    }

    public void Restart()
    {
        ///todo : reset code
        ///
        uiManager.HidePauseWindow();
        
        StartCoroutine(ReadyGame());
    }
    public void Resume()
    {

        uiManager.HidePauseWindow();
        StartCoroutine(ResumeGame());
    }

    IEnumerator ReadyGame()
    {
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
        platformManager.StartScroll();
        yield return null;
    }


    IEnumerator ResumeGame()
    {
        StartCoroutine(uiManager.Countdown());
        yield return null;
        while (!uiManager.countDownDone) yield return new WaitForSeconds(0.01f);
        puang.ResumePuang();
        platformManager.StartScroll();
    }


    IEnumerator EndGame()
    {
        uiManager.fadeScreen.FadeOut();
        yield return null;
    }

}
