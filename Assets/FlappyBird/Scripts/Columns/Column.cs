using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Column : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            // Have we collided with the bird?
            if(other.name.Contains("Bird"))
            {
                // Then the bird scored
                GameManager.Instance.BirdScored();
            }  
        }
    }
}