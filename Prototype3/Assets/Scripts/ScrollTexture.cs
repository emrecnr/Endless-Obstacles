using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    private float scrollX = -0.5f;
    private PlayerController playerController;
    private Renderer renderers;

    private void Start()
    {
        renderers = GetComponent<Renderer>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        
        if (!playerController.gameOver)
        {
            float offsetX = Time.time * scrollX;
            renderers.material.mainTextureOffset = new Vector2(offsetX,0f);
          
        }
        else if (playerController.fastSpeed)
        {
            float offsetX = Time.time * scrollX;
            renderers.material.mainTextureOffset = new Vector2((offsetX*2), 0f);
        }
        
    }
}
