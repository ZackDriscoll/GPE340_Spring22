using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstRifle : Weapon
{
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
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

    public void BurstShoot()
    {
        //Instantiate three bullets at the fire locations of this rifle 
        //This is to act similarly to a pulse rifle seen in other games that shoot three bullets at a time
        GameObject projectile1 = Instantiate(projectilePrefab, firePoint1.position, firePoint1.rotation) as GameObject;
        GameObject projectile2 = Instantiate(projectilePrefab, firePoint2.position, firePoint2.rotation) as GameObject;
        GameObject projectile3 = Instantiate(projectilePrefab, firePoint3.position, firePoint3.rotation) as GameObject;
        Projectile projectileScript1 = projectile1.GetComponent<Projectile>();
        Projectile projectileScript2 = projectile2.GetComponent<Projectile>();
        Projectile projectileScript3 = projectile2.GetComponent<Projectile>();

        //Transfer important information (like damage done) to the bullets
        //-- the bullets will do the rest
        if (projectile1 != null)
        {
            projectile1.layer = gameObject.layer;
            projectileScript1.damageDone = damageDone;
            projectileScript1.lifespan = projectileLifespan;
            projectileScript1.moveSpeed = projectileMoveSpeed;
        }

        if (projectile2 != null)
        {
            projectile2.layer = gameObject.layer;
            projectileScript2.damageDone = damageDone;
            projectileScript2.lifespan = projectileLifespan;
            projectileScript2.moveSpeed = projectileMoveSpeed;
        }

        if (projectile3 != null)
        {
            projectile3.layer = gameObject.layer;
            projectileScript3.damageDone = damageDone;
            projectileScript3.lifespan = projectileLifespan;
            projectileScript3.moveSpeed = projectileMoveSpeed;
        }
    }
}
