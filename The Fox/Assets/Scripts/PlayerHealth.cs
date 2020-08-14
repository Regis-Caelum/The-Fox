using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;
    public float stathealth = 100f;
    public GameObject attack;

    public bool RoutineIsOver = true;

    public GameObject groundpoint;

    public int NumberOfPowerups = 1;
    public int currPowerups = 3;

    public GameObject deathEffect;

    public float attacktime = 100f;

    bool temp = true;
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
            health = 100f;
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void Update()
    {
        /*if(RoutineIsOver == true && attackover == 1)
        {
            attackover = 0;
            currPowerups = 0;
            //attack.SetActive(false);
        }*/


        if (groundpoint != null)
        {
            if (groundpoint.transform.position.y <= -30f)
            {
                TakeDamage(health);
            }
        }
    }

    public void trig()
    {
        StartCoroutine(SummonAttack(attacktime));
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    IEnumerator SummonAttack(float time)
    {
        attack.SetActive(true);
        RoutineIsOver = false;
        yield return new WaitForSecondsRealtime(time);
        attack.SetActive(false);
        RoutineIsOver = true;
    }
}
