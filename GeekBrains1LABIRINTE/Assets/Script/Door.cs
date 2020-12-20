using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int countKey = 0;
    private bool open = false;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.gameObject.GetComponent<Player2>().GetKey() == countKey)
        {
            Debug.Log("Открыто!");
            open = true;
        }
        else if (other.tag == "Player" && other.gameObject.GetComponent<Player2>().GetKey() != countKey)
        {
            Debug.Log("Не хватает ключей!");
        }

        if (other.tag == "Stop")
        {
            open = false;
        }
    }

    private void FixedUpdate()
    {
        if (open)
        {
            transform.Translate(0, Time.deltaTime, 0);
        }
    }

}
