using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Weapon
{
    public Transform firePoint;
    public GameObject projectilePrefab;
    public float projectileMoveSpeed;
    public float projectileLifespan;

    // Start is called before the first frame update
    public override void Start()
    {
        //Run the start function from the parent class
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //Run the update function from the parent class
        base.Update();
    }

    public void ShootPlasmaSphere()
    {
        //Instantiate plasma sphere at the fire location of this rifle 
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as GameObject;
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        //Transfer important information (like damage done) to the sphere
        //-- the sphere will do the rest
        if (projectile != null)
        {
            projectileScript.damageDone = damageDone;
            projectileScript.lifespan = projectileLifespan;
            projectileScript.moveSpeed = projectileMoveSpeed;
        }
    }
}
