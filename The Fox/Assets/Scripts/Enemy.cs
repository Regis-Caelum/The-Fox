using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 100f;

    public GameObject deathEffect;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth temps = collision.GetComponent<PlayerHealth>();
        if(temps != null)
        {
            temps.TakeDamage(20f);
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
