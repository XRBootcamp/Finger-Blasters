using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject NPC;
    public List<WayPoint> patrolPoints;

    public int maxNumberOfNPC;
    public float spawnAfterSeconds;

    public List<GameObject> NPCSpawned = new List<GameObject>();

    void Start()
    {
        InitializeSpawner();
    }

    public void InitializeSpawner()
    {
        StartCoroutine(SimpleSpawner());
    }

    void SpawnNPC()
    {
        int index = Random.Range(0, patrolPoints.Count);

        GameObject newNPC = Instantiate(NPC, patrolPoints[index].transform.position, Quaternion.identity);
        NPCSpawned.Add(newNPC);

        NPCMovement nPC = newNPC.GetComponent<NPCMovement>();
        nPC.SetNPCSpawner(this);
        nPC.SetPatrolPoints(patrolPoints);
        nPC.SetIndex(index);
    }

    IEnumerator SimpleSpawner()
    {
        yield return new WaitForSeconds(spawnAfterSeconds);

        if (NPCSpawned.Count < maxNumberOfNPC)
        {
            SpawnNPC();
        }

        StartCoroutine(SimpleSpawner());
    }
}