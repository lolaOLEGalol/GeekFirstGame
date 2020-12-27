using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button menu;
    [SerializeField] private Button TryAgain;

    private void Awake()
    {
        menu.onClick.AddListener(GoMenu);
        TryAgain.onClick.AddListener(Again);
    }

    public void Again()
    {
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
