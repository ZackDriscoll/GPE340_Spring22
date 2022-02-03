using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserRifle : Weapon
{
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
        //TODO: Instantiate plasma sphere at the fire location of this rifle 
        Debug.Log("Pew Pew Pew!");

        //TODO: Transfer important information (like damage done) to the sphere

        //-- the sphere will do the rest
    }
}
