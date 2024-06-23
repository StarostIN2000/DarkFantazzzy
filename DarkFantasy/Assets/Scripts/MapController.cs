using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist;
    float opDist;
    float optimizerCoolDown;
    public float optimizerCoolDownDur;
    
    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    
    void Update()
    {
        ChunkChecker();
        ChunkOptimizer();
    }

    void ChunkChecker() 
    {
        if (!currentChunk) 
        {
            Debug.Log("пенис");
            return;
        }

        if(pm._moveDirection.x > 0 && pm._moveDirection.y == 0) //right
        {
            if(!Physics2D.OverlapCircle(currentChunk.transform.Find("Right").position, checkerRadius, terrainMask)) 
            {
                noTerrainPosition = currentChunk.transform.Find("Right").position;
                SpawnChunk();
            }
        }
        else if (pm._moveDirection.x < 0 && pm._moveDirection.y == 0) //left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left").position;
                SpawnChunk();
            }
        }
        else if (pm._moveDirection.x == 0 && pm._moveDirection.y > 0) //up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Up").position;
                SpawnChunk();
            }
        }
        else if (pm._moveDirection.x == 0 && pm._moveDirection.y < 0) //down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Down").position;
                SpawnChunk();
            }
        }
        else if (pm._moveDirection.x > 0 && pm._moveDirection.y > 0) //right up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right up").position;
                SpawnChunk();
            }
        }
        else if (pm._moveDirection.x > 0 && pm._moveDirection.y < 0) //right down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Right Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Right Down").position;
                SpawnChunk();
            }
        }
        else if (pm._moveDirection.x < 0 && pm._moveDirection.y > 0) //left up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left up").position;
                SpawnChunk();
            }
        }
        else if (pm._moveDirection.x < 0 && pm._moveDirection.y < 0) //left down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find("Left Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = currentChunk.transform.Find("Left Down").position;
                SpawnChunk();
            }
        }
    }

    void SpawnChunk() 
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }
    void ChunkOptimizer() 
    {
        optimizerCoolDown -= Time.deltaTime;

        if (optimizerCoolDown <= 0f)
        {
            optimizerCoolDown = optimizerCoolDownDur;
        }
        else 
        {
            return;
        }


        foreach (GameObject chunk in spawnedChunks) 
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist) 
            {
                chunk.SetActive(false);
            }
            else 
            { 
                chunk.SetActive(true); 
            }
        }
    }
}
