using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float timeForNewPath;
    bool isUpdatingRandomPosition;


    public Vector3 getNewPosition()
    {
        float x = Random.Range(-200, 200);
        float z = Random.Range(-200, 200);

        Vector3 pos = new Vector3(x, 0, z);
        return pos;
    }


    IEnumerator UpdateRandomPosition()
    {
        isUpdatingRandomPosition = true;
        yield return new WaitForSeconds(timeForNewPath);
        GetNewPath();
        isUpdatingRandomPosition = false;
    }

    
    public void GetNewPath()
    {
        navMeshAgent.SetDestination(getNewPosition());
    }


    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!isUpdatingRandomPosition)
        {
            StartCoroutine(UpdateRandomPosition());
        }
    }

}
