using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Additive);
        Time.timeScale = 1;
    }
}
