using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform playerPoint;
    private bool trigger = false;

    private void Start()
    {
        Canvas.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Canvas.SetActive(true);
            trigger = true;
        }
    }

    private void Update()
    {
        
        if(Vector3.Distance(transform.position, playerPoint.position) > 2f && trigger)
        {
            Canvas.SetActive(false);
            Player.GetComponent<Player2>().SourceBook();
            Destroy(gameObject);

        }
    }


}
