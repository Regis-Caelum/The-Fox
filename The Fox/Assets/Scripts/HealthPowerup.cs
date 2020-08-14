using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthPowerup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine( Power(collision) );
        }
    }

    IEnumerator Power(Collider2D collide)
    {
        PlayerHealth stats = collide.GetComponent<PlayerHealth>();
        if( stats != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            if(stats.stathealth > stats.health)
            {
                stats.health += 10f;
            }
        }

        yield return 0;
        Destroy(gameObject);
    }

}
