using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        public float upForce = 4;           // Upward force of the "flap"
        public float turnMultiplyer = 5;    // Increases the amount the bird turns when flapping

        private bool isDead = false;    // Has the player collider with the wall? 
        private Rigidbody2D rigid;
        private GameManager gameManager;

        // Use this for initialization
        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            gameManager = GameManager.Instance;
        }

        public void Flap()
        {
            // Only flap if the Bird isn't dead yet
            if (!isDead)
            {
                rigid.velocity = Vector2.zero;
                // Give the bird some upward force
                rigid.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
            }
        }

        void Die()
        {
            // Cancel velocity
            rigid.velocity = Vector2.zero;
            // Bird is now dead
            isDead = true;
            // Tell the GameManager about it
            GameManager.Instance.BirdDied();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            Die();
        }

        private void Update()
        {
            //spins the bird based on y velocity
            if (!isDead)transform.eulerAngles = new Vector3(0, 0, rigid.velocity.y * turnMultiplyer);
            //stop the player from going too high (not really needed)
            if(transform.position.y > 5.5f)  Die();
        }
    }
}