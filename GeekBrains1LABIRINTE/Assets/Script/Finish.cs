using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject UIfinish;
    [SerializeField] private AudioSource source;

    private void Awake()
    {
        UIfinish.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Cursor.visible = true;
            source.Play();
            UIfinish.SetActive(true);
        }
    }
}
