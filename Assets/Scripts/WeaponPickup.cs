using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Pickup
{
    public GameObject weaponToPickUp;

    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }

    public override void OnTriggerEnter(Collider other)
    {
        Pawn otherPawn = other.GetComponent<Pawn>();
        if (otherPawn != null)
        {
            otherPawn.EquipWeapon(weaponToPickUp);
        }

        base.OnTriggerEnter(other);
    }
}
