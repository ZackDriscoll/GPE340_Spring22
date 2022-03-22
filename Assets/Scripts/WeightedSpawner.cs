using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedSpawner : MonoBehaviour
{
    public RandomWeightedObject[] objectsToSpawn;
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
                spawnedObject = Instantiate(ChooseSpawnObject(), transform.position, transform.rotation);
                //Reset the countdown
                countdown = respawnTime;
            }
        }
    }

    public GameObject ChooseSpawnObject()
    {
        //Variable to hold spawn object
        GameObject objectToSpawn;

        //Create a second parallel array - this holds the cutoffs (where it changes to the next type)
        //Thus, anything below this cutoff is the parallel weighted object
        //CDF stands for Cumulative Density Function
        float[] CDFArray = new float[objectsToSpawn.Length];

        //Variable to hold cumulative density (total of weights so far)
        float cumulativeDensity = 0;

        //Fill CDFArray with the cutoffs
        for (int i =0; i < objectsToSpawn.Length; i++)
        {
            //Add this object's weight so we know where the cutoff is
            cumulativeDensity += objectsToSpawn[i].weight;

            //Store that in the CDFArray
            CDFArray[i] = cumulativeDensity;
        }

        //Choose a random number up to the max cutoff
        float rand = Random.Range(0.0f, cumulativeDensity);

        //Look through my CDF to find where our random number would fall -- which CDF index would it fall under

        /* Old one at a time method
        for (int i = 0; i < CDFArray.Length; i++)
        {
            if (rand < CDFArray[i])
            {
                //Set the random object that will be spawned
                objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)].objectToSpawn;
                return objectToSpawn;
            }
        }*/

        //Faster, Binary search method built into C#

        int selectedIndex = System.Array.BinarySearch(CDFArray, rand);

        //If Selected Index is negative...
        if (selectedIndex < 0)
        {
            //It's not the exact value, we have to FLIP (bitwise not) the value to find the index we want
            selectedIndex = ~selectedIndex;
        }

        //Set the random object that will be spawned
        objectToSpawn = objectsToSpawn[selectedIndex].objectToSpawn;
        return objectToSpawn;
    }

    private void OnDrawGizmos()
    {
        Matrix4x4 myNewCoordinateSystem = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.matrix = myNewCoordinateSystem;
        Gizmos.color = Color.Lerp(Color.red, Color.clear, 0.5f);
        Gizmos.DrawRay(Vector3.zero, Vector3.forward * 0.5f);
    }
}
