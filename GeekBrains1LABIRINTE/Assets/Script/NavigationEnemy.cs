using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationEnemy : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform finishPoint;
    [SerializeField] private Transform playerPoint;
    private float timePatrul = 2f;
    private float waitPatrul;
    private float waitAtack = 0;

    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(finishPoint.position);
        waitPatrul = timePatrul;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "checkEnemy")
        {
            Debug.Log("УВИДЕЛ ИГРОКА!");
            GetComponent<NavMeshAgent>().SetDestination(playerPoint.position);

            if (Vector3.Distance(transform.position, playerPoint.position) < 1f && waitAtack <= 0)
            {
                Debug.Log("УБИЛ!");
                waitAtack = timePatrul;
            }
            waitAtack -= Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "checkEnemy")
        {
           GetComponent<NavMeshAgent>().SetDestination(startPoint.position);
        }
    }

    private void Check()
    {
        if (Vector3.Distance(transform.position, finishPoint.position) < 1)
        {
            if(waitPatrul <= 0)
            {
                GetComponent<NavMeshAgent>().SetDestination(startPoint.position);
                Debug.Log("Достиг финиша");
                waitPatrul = timePatrul;
            }

            waitPatrul -= Time.deltaTime;
            
        }
        else if (Vector3.Distance(transform.position, startPoint.position) < 1)
        {
            if (waitPatrul <= 0)
            {
                GetComponent<NavMeshAgent>().SetDestination(finishPoint.position);
                Debug.Log("Достиг старта");
                waitPatrul = timePatrul;
            }
            waitPatrul -= Time.deltaTime;
        }

        
    }
    void Update()
    {
        Check();
    }
}
