using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtScorchedEarth : MonoBehaviour
{
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            if (collision.gameObject.tag == "Player1")
            {
                Debug.Log("Test entre joueur 1");
            }
            else if (collision.gameObject.tag == "Player2")
            {
                Debug.Log("Test entre joueur 2");
            }
        }
    }
}
