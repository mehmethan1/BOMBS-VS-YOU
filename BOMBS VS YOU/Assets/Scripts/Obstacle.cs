using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;

    public float speed;

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<smooth>().health -= damage;
            Destroy(gameObject);
        }

        if (other.CompareTag("Players"))
        {
            other.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }

    
}
