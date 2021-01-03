using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button menu;
    [SerializeField] private Button TryAgain;
    [SerializeField] private AudioSource click;

    private void Awake()
    {
        menu.onClick.AddListener(GoMenu);
        TryAgain.onClick.AddListener(Again);
    }

    public void Again()
    {
        UnityEngine.Cursor.visible = true;
        click.Play();
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        click.Play();
        Invoke("LoadMenu", 0.3f);
        
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
