using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    private bool esc = false;
    [SerializeField] private GameObject Pause;
    [SerializeField] private AudioSource btn;

    private float time = 0.5f;
    private float Wait;

    private void Awake()
    {
        Pause.SetActive(false);
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape) && esc == false && Wait <= 0)
        {
            UnityEngine.Cursor.visible = true;
            Debug.Log("ДА");
            Pause.SetActive(true);
            Time.timeScale = 0f;
            esc = true;

            Wait = time;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && esc == true && Wait <= 0)
        {
            UnityEngine.Cursor.visible = false;
            Debug.Log("НЕТ");
            Pause.SetActive(false);
            esc = false;
            Time.timeScale = 1f;

            Wait = time;
        }

        Wait -= Time.deltaTime;
    }

    public void Resume()
    {
        UnityEngine.Cursor.visible = false;

        btn.Play();

        Debug.Log("НЕТ");
        Pause.SetActive(false);
        esc = false;
        Time.timeScale = 1f;

        Wait = time;
    }

    public void Menu()
    {
        btn.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}





