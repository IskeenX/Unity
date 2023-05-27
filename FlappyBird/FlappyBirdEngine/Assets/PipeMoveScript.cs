using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -45;

    void Update()
    {
        PipeMovement();
    }

    void PipeMovement()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime * 2;
        if(transform.position.x < deadZone)//Destroy pipes which are on left side
        {
            Destroy(gameObject);
        }
    }
}