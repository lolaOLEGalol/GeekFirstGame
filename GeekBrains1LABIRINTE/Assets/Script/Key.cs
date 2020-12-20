using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Key")
        {
            player.GetComponent<Player2>().key++;
            Destroy(other.gameObject);
        }
    }
}
