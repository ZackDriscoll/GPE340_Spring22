using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [Header("Components")]
    //Variable to control the animator object
    private Animator anim;

    //Weapon script reference
    public Weapon weapon;

    [Header("Transforms")]
    //Weapon mount point
    public Transform weaponMountPoint;

    [Header("Data")]
    //Bool to check if the player is crouching or not
    [SerializeField] bool isCrouch;

    //Meters per second
    public float moveSpeed = 1;

    //Degrees per second
    public float rotateSpeed = 360;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        weapon = GetComponent<Weapon>();
    }

    public void UnequipWeapon()
    {
        //Destroy the equipped weapon
        Destroy(weapon.gameObject);

        //Make sure the weapon variable is set to null
        weapon = null;
    }

    public void EquipWeapon(GameObject weaponPrefabToEquip)
    {
        //Check if the weapon is null before trying to unequip a weapon
        if (weapon != null)
        {
            //Unequip the old weapon
            UnequipWeapon();
        }
        else
        {
            //Instantiate the weapon to equip
            GameObject newWeapon = Instantiate(weaponPrefabToEquip, weaponMountPoint.position, weaponMountPoint.rotation);

            //Make it so the weapon's parent (transform.parent) is the correct part of the player
            newWeapon.transform.parent = weaponMountPoint;

            //Set this pawn, so the new weapon is the weapon used by code
            weapon = newWeapon.GetComponent<Weapon>();
        }
    }

    //Move the player using root motion blend tree variables
    public void Move(Vector3 moveVector)
    {
        //Apply speed
        moveVector = moveVector * moveSpeed;

        //Send parameters in to animator
        anim.SetFloat("Right", moveVector.x);
        anim.SetFloat("Forward", moveVector.z);
    }

    public void RotateToMouse(Vector3 targetPoint)
    {
        //Find the rotation that would be looking at that target point
        //Find the vector to the point
        Vector3 targetVector = targetPoint - transform.position;

        //Find rotation down that vector
        Quaternion targetRotation = Quaternion.LookRotation(targetVector, Vector3.up);

        //Change my rotation (slowly) towards that targeted location
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    //Function to toggle crouching mechanic
    public void Crouch()
    {
        //As long as the player is pressing the left control or c keys, play the crouch animation
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.C))
        {
            isCrouch = !isCrouch;
            anim.SetBool("Crouch", isCrouch);
        }
    }
}
