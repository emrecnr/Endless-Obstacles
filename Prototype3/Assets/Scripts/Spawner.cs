
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;

    private Vector3 spawnPos = new Vector3(25, 0, 0);

    private float spawnTime = 2;
    private float spawnRate = 2;

    private PlayerController playerController;
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnRate);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
  
    void Spawn() 
    { 
        if (playerController.gameOver==false)
        {
            int randomIndex = Random.Range(0, obstacles.Length);
            GameObject randomObstacle = obstacles[randomIndex];

            Instantiate(randomObstacle, spawnPos, randomObstacle.transform.rotation);
            
        }
        
    
    }    
}
