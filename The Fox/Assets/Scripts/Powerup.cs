using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Powerup : MonoBehaviour
{
    bool timer = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Power(collision);
        }
    }

    void Power(Collider2D collide)
    {
        PlayerHealth stats = collide.GetComponent<PlayerHealth>();
        if( stats != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            if(stats.currPowerups < stats.NumberOfPowerups )
            {
                stats.currPowerups += 1;
            }else if(stats.currPowerups == stats.NumberOfPowerups)
            {
                stats.trig();
                timer = stats.RoutineIsOver;
                Debug.Log(timer);
                stats.currPowerups = 0;
            }
        }
        Destroy(gameObject);
    }

}
