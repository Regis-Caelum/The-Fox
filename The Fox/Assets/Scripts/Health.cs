using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text score;
    public GameObject objects;
    void Update()
    {
        if(objects.GetComponent<PlayerHealth>() != null)
        {
            score.text = objects.GetComponent<PlayerHealth>().health.ToString();
        }
        
    }
}
