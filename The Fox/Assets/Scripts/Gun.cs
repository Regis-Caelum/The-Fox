using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;

    public Transform firepoint;
    public Transform crouchfirepoint;
    public GameObject impactEffect;
    public LineRenderer line;
    public LineRenderer crouchline;

    bool shoot = false;

    public Animator animator;


    void Update()
    {
        if (shoot)
        {
            animator.SetBool("shooting",shoot);
            shoot = false;
        }
    }
    public void Fire()
    {
        if (animator.GetBool("crouching"))
        {
            StartCoroutine(CrouchShoot());
        }
        else
        {
            StartCoroutine(StandShoot());
        }
        shoot = true;
    }

    IEnumerator StandShoot()
    {
       // animator.SetBool("shooting", true);
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

        yield return new WaitForSeconds(0.2f);

        line.enabled = false;
    }

    IEnumerator CrouchShoot()
    {
        // animator.SetBool("shooting", true);
        RaycastHit2D Hitinfo = Physics2D.Raycast(crouchfirepoint.position, crouchfirepoint.right);

        if (Hitinfo)
        {
            Enemy enemy = Hitinfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Instantiate(impactEffect, Hitinfo.point, Quaternion.identity);

            crouchline.SetPosition(0, crouchfirepoint.position);
            crouchline.SetPosition(1, Hitinfo.point);
        }
        else
        {
            crouchline.SetPosition(0, crouchfirepoint.position);
            crouchline.SetPosition(1, crouchfirepoint.position + crouchfirepoint.position * range);
        }


        line.enabled = true;

        yield return new WaitForSeconds(0.2f);

        line.enabled = false;
    }
}
