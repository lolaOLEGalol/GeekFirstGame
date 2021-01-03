using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class NavigationEnemy : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform finishPoint;
    [SerializeField] private Transform playerPoint;
    private float timePatrul = 2f;
    private float waitPatrul;
    private float waitAtack = 0;

    [SerializeField] private GameObject CanvasRun;
    [SerializeField] private GameObject TextRun;

    [SerializeField] private AudioSource atack;
    [SerializeField] private AudioSource walf;




    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(finishPoint.position);
        waitPatrul = timePatrul;
        MigalkaRunTrue();
    }

    private void MigalkaRunTrue()
    {
        TextRun.SetActive(true);
        Invoke("MigalkaRunFalse", 0.7f);
    }

    private void MigalkaRunFalse()
    {
        TextRun.SetActive(false);
        Invoke("MigalkaRunTrue", 0.7f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "checkEnemy")
        {
            CanvasRun.SetActive(true);
            atack.Play();
        }

        if (other.tag == "checkEnemuSound")
        {
            walf.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "checkEnemy")
        {
            GetComponent<Animator>().SetBool("is_walk", false);
            Debug.Log("УВИДЕЛ ИГРОКА!");


            GetComponent<Animator>().SetBool("is_run", true);
            GetComponent<NavMeshAgent>().speed = 5;
            GetComponent<NavMeshAgent>().SetDestination(playerPoint.position);

            if (Vector3.Distance(transform.position, playerPoint.position) < 1f && waitAtack <= 0)
            {
                
                TextRun.SetActive(false);
                SceneManager.LoadScene(2);

                Debug.Log("УБИЛ!");

                UnityEngine.Cursor.visible = true;
                waitAtack = timePatrul;
            }
            if (Vector3.Distance(transform.position, playerPoint.position) < 3f)
            {
                GetComponent<Animator>().SetBool("is_atack", true);
            }
            if (Vector3.Distance(transform.position, playerPoint.position) > 3f)
            {
                GetComponent<Animator>().SetBool("is_atack", false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "checkEnemy")
        {
            CanvasRun.SetActive(false);

            GetComponent<Animator>().SetBool("is_atack", false);
            GetComponent<Animator>().SetBool("is_run", false);
            GetComponent<Animator>().SetBool("is_walk", true);
            GetComponent<NavMeshAgent>().speed = 2;
            GetComponent<NavMeshAgent>().SetDestination(startPoint.position);

            atack.Stop();
        }

        if (other.tag == "checkEnemuSound")
        {
            walf.Stop();
        }

    }

    
    private void Check()
    {
        if (Vector3.Distance(transform.position, finishPoint.position) < 1f)
        {
            GetComponent<Animator>().SetBool("is_idle", true);
            if (waitPatrul <= 0)
            {
                GetComponent<Animator>().SetBool("is_walk", true);
                GetComponent<NavMeshAgent>().SetDestination(startPoint.position);
                Debug.Log("Достиг финиша");
                waitPatrul = timePatrul;
            }

            waitPatrul -= Time.deltaTime;
            
        }
        else if (Vector3.Distance(transform.position, startPoint.position) < 1f)
        {
            GetComponent<Animator>().SetBool("is_idle", true);
            if (waitPatrul <= 0)
            {
                GetComponent<Animator>().SetBool("is_walk", true);
                GetComponent<NavMeshAgent>().SetDestination(finishPoint.position);
                Debug.Log("Достиг старта");
                waitPatrul = timePatrul;
            }
            waitPatrul -= Time.deltaTime;
        }
        else
        {
            GetComponent<Animator>().SetBool("is_idle", false);
        }

        
    }
    void Update()
    {
        Check();
    }
}
