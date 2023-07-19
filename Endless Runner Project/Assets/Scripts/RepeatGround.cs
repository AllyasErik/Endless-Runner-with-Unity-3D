using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x - 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.isGameOver)
        {
            return;
        }

        transform.Translate(Vector3.left * Time.deltaTime * speed);
        

        if(transform.position.x < repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
