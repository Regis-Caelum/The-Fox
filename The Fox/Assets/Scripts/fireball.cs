using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{

    public float speed = 20f;
    public float damage = 40f;
    public Rigidbody2D body;
    public GameObject impacteffect;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.right*speed;
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Enemy enemy = hitinfo.transform.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
        }

        Instantiate(impacteffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
