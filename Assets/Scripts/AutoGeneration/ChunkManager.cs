using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour
{
    
	public Transform playerTransformComponent;

	public Chunk[] chunkPrefabs;

	public Chunk firstChunk;

	private List<Chunk> spawnedChunks = new List<Chunk>();

	public Vector3 offset;



    void Start()
    {
        spawnedChunks.Add(firstChunk);
    }

    void Update()
    {
        if(playerTransformComponent.position.z > spawnedChunks[spawnedChunks.Count - 1].endPoint.position.z - 200){
        	SpawnChunk();
        }
    }

    void SpawnChunk(){

    	Chunk newChunk = Instantiate(chunkPrefabs[Random.Range(0, chunkPrefabs.Length)]);
    	newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].endPoint.position - newChunk.startPoint.localPosition + offset;
    	spawnedChunks.Add(newChunk);

    	if(spawnedChunks.Count >= 3){
    		Destroy(spawnedChunks[0].gameObject);
    		spawnedChunks.RemoveAt(0);
    	}
    }
}
