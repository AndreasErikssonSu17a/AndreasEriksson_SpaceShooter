using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : ShootingEnemy
{
    protected override void Start()
    {
        direction = -90f;
    }

    protected override void FixedUpdate()
    {
        if (Input.GetButton("Fire1"))
        {
            base.FixedUpdate();
        }

        if (canShoot == false)
        {
            Cooldown();
        }
    }
}