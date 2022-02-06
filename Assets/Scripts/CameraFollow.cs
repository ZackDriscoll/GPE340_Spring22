using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //Transform of the player
    public Transform playerToFollow;

    //Variable offset for the camera
    [Header("Camera Movement:"), SerializeField, Tooltip("The amount of offset from the player's position.")]
    protected Vector3 cameraOffset;

    //Speed the camera will move at
    [SerializeField, Tooltip("The speed the camera travels to keep up with the player.")]
    protected float cameraSpeed;


    // Update is called once per frame
    void Update()
    {
        //Call the function to follow the player with the offset.
        MoveWithPlayer();
    }

    /// <summary>
    /// Moves the camera's position along with the player
    /// </summary>
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
