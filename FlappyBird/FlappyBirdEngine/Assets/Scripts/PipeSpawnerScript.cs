using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    private float spawnRate = 2f;
    private float timer = 0f;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        SpawnRate();
    }

    private void SpawnRate()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnRate = Random.Range(2, 4);
            SpawnPipe();
            timer = 0;
        }   
    }
    private void SpawnPipe()
    {
        //Randomize pipe position in y axis
        float lowestPoint = -11;
        float highestPoint = 35;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation); //x is constant, y changes, z is 0
    }
}