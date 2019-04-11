using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ScrollObject : MonoBehaviour
    {
        private Rigidbody2D rigid;
        GameManager gameManager;

        private void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();

        }

        // Use this for initialization
        void Start()
        {
            gameManager = GameManager.Instance;
            rigid.velocity = new Vector2(gameManager.scrollSpeed, 0);
        }

        // Update is called once per frame
        void Update()
        {
            // Check if game is over
            if (gameManager.gameOver)
            {
                // Cancel velocity to stop scrolling
                rigid.velocity = Vector2.zero;
            }
        }
    }
}
