using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public GameObject projectile;
	private Rigidbody2D rbody2d;
    private GameObject clone;

    public float fireSpeed;

	//Cooldown variabler.
    public float cooldown;
    private bool canShoot;
    private float waitTimer;

    void Start ()
	{
		rbody2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
	{
		if (Input.GetButton("Fire1") && canShoot)
		{
			Shoot();
            canShoot = false;
		}

        if (canShoot == false)
        {
            waitTimer += Time.deltaTime;

            if (waitTimer >= cooldown)
            {
                canShoot = true;
                waitTimer = 0f;
            }
        }
	}

	public void Shoot()
	{
        clone = (GameObject)Instantiate(projectile, rbody2d.transform.position, Quaternion.identity);
        clone.transform.Rotate(Vector3.forward * -90f);
        clone.GetComponent<Rigidbody2D>().velocity = projectile.transform.up * fireSpeed;

		clone.GetComponent<AudioSource>().Play();
	}
}