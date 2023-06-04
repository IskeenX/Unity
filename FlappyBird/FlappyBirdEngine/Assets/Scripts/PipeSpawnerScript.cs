using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2f;
    public float timer = 0f;

    public void SpawnRate()
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
    public void SpawnPipe()
    {
        //Randomize pipe position in y axis
        float lowestPoint = -11;
        float highestPoint = 35;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation); //x is constant, y changes, z is 0
    }
}