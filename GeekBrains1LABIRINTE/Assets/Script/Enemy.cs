using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    public Transform player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Invert")
        {
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(player);
        }
    }
    private void Update()
    {
        transform.Translate(0, 0, Time.deltaTime * speed);
    }
}
