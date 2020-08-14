using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadly : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth temp = collision.GetComponent<PlayerHealth>();
        if(temp != null)
        {
            temp.TakeDamage(temp.health);
        }
    }
}
