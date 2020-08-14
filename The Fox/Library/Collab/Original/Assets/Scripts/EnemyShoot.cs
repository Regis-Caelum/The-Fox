using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Transform firepoint;
      public GameObject fireballPrefab;

    // Update is called once per frame
    void Update()
    {
        Fired();
    }

    void Fired()
    {
        Instantiate(fireballPrefab, firepoint.position, firepoint.rotation);
    }
}
