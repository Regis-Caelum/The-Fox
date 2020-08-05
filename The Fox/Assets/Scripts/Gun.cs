using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Transform firepoint;
    public GameObject impactEffect;
    public LineRenderer line;

    public void fire()
    {
        StartCoroutine( Shoot() );
    }

    IEnumerator Shoot()
    {
        RaycastHit2D Hitinfo = Physics2D.Raycast(firepoint.position, firepoint.right);

        if (Hitinfo)
        {
            Enemy enemy = Hitinfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffect, Hitinfo.point, Quaternion.identity);

            line.SetPosition(0, firepoint.position);
            line.SetPosition(1, Hitinfo.point);
        }
        else
        {
            line.SetPosition(0, firepoint.position);
            line.SetPosition(1, firepoint.position + firepoint.position*range);
        }

        line.enabled = true;

        yield return new WaitForSeconds(0.02f);

        line.enabled = false;
    }
}
