using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float yOffset = 10;
    public float xOffset = 4;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        SpawnRate();
    }

    void SpawnRate()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            timer = 0;
        }
    }
    void SpawnPipe()
    {
        //Randomize pipe position in x and y axis
        float lowestPointy = transform.position.y - yOffset;
        float highestPointy = transform.position.y + yOffset;
        float lowestPointx = transform.position.x - xOffset;
        float highestPointx = transform.position.x + xOffset;
        Instantiate(pipe, new Vector3(Random.Range(lowestPointx+3, highestPointx), Random.Range(lowestPointy, highestPointy), 0), transform.rotation); //x is constant, y changes, z is 0
    }
}