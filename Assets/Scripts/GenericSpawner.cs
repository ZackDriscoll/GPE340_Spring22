using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float respawnTime;

    private GameObject spawnedObject;
    private float countdown;


    // Start is called before the first frame update
    void Start()
    {
        countdown = respawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        //If the spawned object is already spawned
        if (spawnedObject != null)
        {
            //Do nothing
            return;
        }
        //Else
        else
        {
            //Countdown our timer
            countdown -= Time.deltaTime;
            //If our countdown hits zero--
            if (countdown <= 0)
            {
                //Spawn (and store) the object
                spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation);
                //Reset the countdown
                countdown = respawnTime;
            }
        }
    }

    private void OnDrawGizmos()
    {
        /*Matrix4x4 myNewCoordinateSystem = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.color = Color.Lerp(Color.red, Color.clear, 0.7f);
        Gizmos.matrix = myNewCoordinateSystem;
        Gizmos.DrawRay(Vector3.zero, Vector3.forward);*/


        Matrix4x4 myNewCoordinateSystem = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.matrix = myNewCoordinateSystem;
        Gizmos.color = Color.Lerp(Color.red, Color.clear, 0.5f);
        Gizmos.DrawRay(Vector3.zero, Vector3.forward * 0.5f);
    }
}
