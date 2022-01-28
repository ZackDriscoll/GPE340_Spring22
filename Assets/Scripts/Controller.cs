using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Pawn pawn;
    public Camera playerCamera;

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

        //Limit the vector magnitude to 1
        moveVector = Vector3.ClampMagnitude(moveVector, 1.0f);

        //Tell the pawn to move
        pawn.Move(moveVector);


        //Rotate player to face mouse
        RotateTowards();

        //Call the crouch function
        pawn.Crouch();
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
}
