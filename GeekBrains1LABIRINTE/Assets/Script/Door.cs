using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Door : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int countKey = 0;
    [SerializeField] private TextMeshProUGUI myText;
    public GameObject Canvas;
    private string myTextstr;
    private int key;
    private bool open = false;

    [SerializeField] private AudioSource openDoor;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if(other.tag == "Player")
        {
            Canvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Canvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        myTextstr = key + "/" + countKey;
        myText.text = myTextstr;

        if (other.tag == "Player" && key == countKey)
        {
            Debug.Log("Открыто!");
            openDoor.Play();
            open = true;
        }
        else if (other.tag == "Player" && key != countKey)
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

        key = player.GetComponent<Player2>().GetKey();

        if (open)
        {
            transform.Translate(0, Time.deltaTime, 0);
        }
    }

}
