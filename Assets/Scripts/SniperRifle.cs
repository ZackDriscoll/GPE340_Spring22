using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : Weapon
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

    public void SniperShoot()
    {
        //TODO: Create a raycast to act as the shoot functionality and spawn particles to "visualize" the shot
    }
}
