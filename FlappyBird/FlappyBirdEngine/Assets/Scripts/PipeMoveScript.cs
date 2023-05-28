using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    private float moveSpeed = 5f;
    private float deadZone = -100f;

    void Update()
    {
        PipeMovement();
    }

    private void PipeMovement()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime*5;
        if(transform.position.x < deadZone)//Destroy pipes which are on left side
        {
            Destroy(gameObject);
        }
    }
}