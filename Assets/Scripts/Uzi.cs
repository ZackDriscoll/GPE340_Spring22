using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
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

    public void AutoShoot()
    {
        //Instantiate three bullets at the fire locations of this rifle 
        //This is to act similarly to a pulse rifle seen in other games that shoot three bullets at a time
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation) as GameObject;
        Projectile projectileScript = projectile.GetComponent<Projectile>();

        //Transfer important information (like damage done) to the bullets
        //-- the bullets will do the rest
        if (projectile != null)
        {
            projectile.layer = gameObject.layer;
            projectileScript.damageDone = damageDone;
            projectileScript.lifespan = projectileLifespan;
            projectileScript.moveSpeed = projectileMoveSpeed;
        }
    }
}
