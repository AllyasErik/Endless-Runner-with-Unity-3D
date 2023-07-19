using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 5f;
    private float speed1 = 8f;
    private float speed2 = 12f;
    private float leftBoundary = -7f;

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isGameOver)
        {
            return;
        }

        if (gameObject.CompareTag("ObstacleWithSenzor"))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.left * Time.deltaTime * Random.Range(speed1, speed2));
        }
        

        if(transform.position.x < leftBoundary)
        {
            Destroy(gameObject);
        }
    }
}
