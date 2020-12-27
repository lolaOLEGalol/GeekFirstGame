using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private GameObject light;
    private float waitTime;
    private bool trigger;


    private void Awake()
    {
        trigger = true;
        waitTime = 0f;
    }
    void Update()
    {
        if (waitTime <= 0)
        {
            waitTime = time;
            if (trigger)
            {
                light.SetActive(true);
                trigger = false;
            }
            else
            {
                
                light.SetActive(false);
                trigger = true;
            }
        }
        waitTime -= Time.deltaTime;
    }
}
