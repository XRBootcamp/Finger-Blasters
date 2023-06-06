using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCMovement : MonoBehaviour
{
    [Range(0f, 1f)] public float enemyVelocity = 1;
    //Dictates wheter the agent waits on each mode.
    [SerializeField] bool patrolWaiting = false;
    //The total time we wait at each node.
    [SerializeField] float totalWaitTime = 3f;
    //The probability of switching direction.
    [SerializeField] float switchProbability = 0.2f;
    //The List of all patrol nodes to visit.
    [SerializeField] List<WayPoint> patrolPoint = null;
    //Private variables for base behaviours.
    NavMeshAgent navMeshAgent;

    [SerializeField] GameObject containerReference;
    [SerializeField] NPCStats targetReference;

    int currentPatrolIndex = 0;

    bool traveling;
    bool waiting;
    bool patrolForward;
    float waitTimer;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if (patrolPoint != null && patrolPoint.Count >= 2)
            {            
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patrolling behaviour.");
            }
        }
    }

    public void SetPatrolPoints(List<WayPoint> points)
    {
        patrolPoint = points;
    }

    public void SetIndex(int index)
    {
        currentPatrolIndex = index;
    }

    public void SetNPCSpawner(NPCSpawner whichSpawner)
    {
        targetReference.SetSpawner(whichSpawner);
    }

    void Update()
    {
        if (containerReference != null)
        {
            Vector3 targetPostition = new Vector3(ShootGameManager.instance.playerPos.x, containerReference.transform.position.y, ShootGameManager.instance.playerPos.z);
            containerReference.transform.LookAt(targetPostition);
        }

        if (traveling && navMeshAgent.remainingDistance <= 0.01f) //To modify in base at you desired distance
        {
            traveling = false;

            if (patrolWaiting == false)
            {
                waiting = true;
                waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (waiting)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= totalWaitTime)
            {
                waiting = false;
                ChangePatrolPoint();
                SetDestination();
            }
        }
    }
    private void SetDestination()
    {
        if (patrolPoint != null)
        {
            Vector3 targetVector = patrolPoint[currentPatrolIndex].transform.position;
            navMeshAgent.SetDestination(targetVector);
            traveling = true;
        }
    }

    private void ChangePatrolPoint()
    {
        if (Random.Range(0f, 1f) <= switchProbability)
        {
            patrolForward = !patrolForward;
        }

        if (patrolForward)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoint.Count;
        }
        else
        {
            if (--currentPatrolIndex < 0)
            {
                currentPatrolIndex = patrolPoint.Count - 1;
            }
        }
    }
}