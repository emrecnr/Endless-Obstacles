using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMovement : MonoBehaviour
{
    private float moveSpeed = 20f;
    private PlayerController playerController;
    private float leftBound = -10f;
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        if (playerController.gameOver == false)
        {
            if (playerController.fastSpeed)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (moveSpeed * 1.5f));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
                    
            }
            
        }
        if (transform.position.x<leftBound&&gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
