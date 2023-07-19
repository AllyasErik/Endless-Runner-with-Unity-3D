using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnObstacles : MonoBehaviour
{

    public GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            InvokeRepeating("SpawnObstacle", 1, 3);
        }
        else
        {
            InvokeRepeating("SpawnObstacle", 1, Random.Range(1, 2.5f));
        }
    }

    public void SpawnObstacle()
    {
        if (PlayerController.isGameOver)
        {
            return;
        }

        int idx = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[idx], new Vector3(9, obstacles[idx].transform.position.y, obstacles[idx].transform.position.z), obstacles[idx].transform.rotation);
    }
}
