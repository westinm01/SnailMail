using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGeneration : MonoBehaviour
{
    public List <GameObject> obstacles = new List<GameObject>();
    public float generationTimer = 6f;
    private float generationTimePassed = 0f;

    private int numOfObstacles = 0;
    // Start is called before the first frame update
    void Start()
    {
        numOfObstacles = obstacles.Count;
    }

    // Update is called once per frame
    void Update()
    {
        generationTimePassed += Time.deltaTime;
        if (generationTimePassed >= generationTimer)
        {
            int rando = Random.Range(0, numOfObstacles);
            GameObject newObstacle = Instantiate(obstacles[rando], this.transform, false);
            float randomY = Random.Range(-3f, 3f);
            newObstacle.transform.position = new Vector3(19.0f, randomY, 5f);
            generationTimePassed = 0f;
            Destroy(newObstacle, 25f);
        }
    }
}
