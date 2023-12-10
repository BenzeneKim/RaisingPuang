using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GotoMinigame : MonoBehaviour
{
    public void ChangeScene()
    {
        GameManager.instance.ClothState = 0;
        GameManager.instance.Save();
        SceneManager.LoadScene(1);
    }
}
