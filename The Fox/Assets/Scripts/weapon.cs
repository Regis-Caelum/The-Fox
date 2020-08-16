using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public Animator animator;
	public void Shoot()
	{
		animator.SetBool("shooting", true);
		Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		//animator.SetBool("shooting", false);
	}
}
