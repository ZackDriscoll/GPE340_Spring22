using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Transform of the player
    public Transform playerToFollow;

    //Variable offset for the camera
    [SerializeField]
    protected Vector3 cameraOffset;

    //Speed the camera will move at
    [SerializeField]
    protected float cameraSpeed;


    // Update is called once per frame
    void Update()
    {
        //Call the function to follow the player with the offset.
        MoveWithPlayer();
    }

    //Camera will track the player's movement
    void MoveWithPlayer()
    {
        //Create a vector for position to be at.
        Vector3 positionToBe;

        //Calaculate position to be at from player's position + offset;
        positionToBe = playerToFollow.position + cameraOffset;

        //Move towards that position.
        transform.position = Vector3.MoveTowards(transform.position, positionToBe, cameraSpeed * Time.deltaTime);
    }
}
