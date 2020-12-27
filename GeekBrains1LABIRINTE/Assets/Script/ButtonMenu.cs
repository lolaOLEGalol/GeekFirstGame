using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button settings;
    [SerializeField] private Button quit;
    [SerializeField] private Button back;
    [SerializeField] private GameObject canvasSettings;
    [SerializeField] private GameObject canvas;

    [SerializeField] private Toggle toggleMusic;

    private void Awake()
    {
        canvasSettings.SetActive(false);
        play.onClick.AddListener(Play);
        settings.onClick.AddListener(Settings);
        quit.onClick.AddListener(Quit);
        back.onClick.AddListener(Back);

        toggleMusic.onValueChanged.AddListener(Music);
    }

    public void Back()
    {
        canvasSettings.SetActive(false);
        canvas.SetActive(true);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        Debug.Log("Привет, я работаю!");
        canvas.SetActive(false);
        canvasSettings.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Music(bool music)
    {
        if(music)
        {
            AudioListener.volume = 1f;
            Debug.Log("вкл");
        }
        else
        {
            AudioListener.volume = 0f;
            Debug.Log("выкл");
        }
        
    }

    
}
