using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Weapon
{
    public Transform firePoint;

    [Header("Particle Prefabs")]
    public GameObject muzzleFlashParticlePrefab;
    public GameObject hitTargetParticlePrefab;

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

    public void SniperShoot()
    {
        //Instantiate Particle at firepoint
        Instantiate(muzzleFlashParticlePrefab, firePoint.position, firePoint.rotation);

        //Raycast to see if anything is in front of our gun
        //If so...
        RaycastHit hitInfo;
        if (Physics.Raycast(firePoint.position, firePoint.transform.forward, out hitInfo))
        {
            //Instantiate a particle at the hit point
            Instantiate(hitTargetParticlePrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            //Check if that object we hit has a health component -- if so:
            Health otherHealth = hitInfo.collider.gameObject.GetComponent<Health>();
            if (otherHealth != null)
            {
                //Make it take damage
                otherHealth.TakeDamage(damageDone);
            }
        }
    }
}
