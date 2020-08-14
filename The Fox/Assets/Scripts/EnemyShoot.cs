using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public Transform firepoint;
    public GameObject fireballPrefab;
    public float fireRate = 2f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine( Fired(fireRate) );
    }

    IEnumerator Fired (float time)
    {
        Instantiate(fireballPrefab, firepoint.position, firepoint.rotation);
        yield return new WaitForSecondsRealtime(time);
    }
}
