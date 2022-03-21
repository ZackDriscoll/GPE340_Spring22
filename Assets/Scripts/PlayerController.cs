using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Pawn pawn;
    public Camera playerCamera;

    [SerializeField]
    private GameObject playerRespawner;

    // Start is called before the first frame update
    void Start()
    {
        //Make sure the camera is loaded
        if (playerCamera == null)
        {
            Debug.LogWarning("ERROR: No camera set!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Send my move comamnd to my pawn
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //Adjust this move vector, so that it is based on the direction the character is facing
        //Find out what "local" (Forward/Right) would move me in the world (North/South) that matches my input

        //Should normally be passing in the positive of moveVector, but direction movement was opposite of intended,
        //so passing in the negative for moveVector fixes that
        moveVector = pawn.transform.InverseTransformDirection(-moveVector);

        //Limit the vector magnitude to 1
        moveVector = Vector3.ClampMagnitude(moveVector, 1.0f);

        //Read Fire Button inputs
        GetButtonInputs();

        //Tell the pawn to move
        pawn.Move(moveVector);

        //Rotate player to face mouse
        RotateTowards();

        //Call the crouch function
        pawn.Crouch();
    }

    private void GetButtonInputs()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (pawn != null)
            {
                if (pawn.weapon != null)
                {
                    pawn.weapon.OnPullTrigger.Invoke();
                }
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            pawn.weapon.OnReleaseTrigger.Invoke();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            pawn.weapon.OnAlternateAttackStart.Invoke();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            pawn.weapon.OnAlternateAttackEnd.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            pawn.health.TakeDamage(10);
        }
    }

    //Function to have the player rotate towards the mouse screen position
    public void RotateTowards()
    {
        //Create a plane object (a mathematical representation of all the points in 2D)
        Plane groundPlane;

        //Set that plane so it is the X,Z plane the player is standing on
        groundPlane = new Plane(Vector3.up, pawn.transform.position);

        //Cast a ray from our camera toward the plane, thorught our mouse cursor
        float distance;
        Ray cameraRay = playerCamera.ScreenPointToRay(Input.mousePosition);
        groundPlane.Raycast(cameraRay, out distance);

        //Find where that ray hits the plane
        Vector3 raycastPoint = cameraRay.GetPoint(distance);

        //Rotate towards that point
        pawn.RotateToMouse(raycastPoint);
    }

    public void Respawn()
    {
        //Reset the player's transform to the respawn point instead of destroying the player
        transform.position = playerRespawner.transform.position;
    }
}
