using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMinion : AIController
{
    private Pawn pawn;
    private NavMeshAgent agent;

    private PlayerController player;

    public float maxShootingError = 1.0f;
    public float minShootingDistance = 1.0f;
    public float maxShootingDistance = 5.0f;
    public float fireDelay = 0.0f;

    private float countdown = 0.0f;

    public float noLeadDistance = 0.0f; //Use 0% lead modifier
    public float maxLeadDistance = 25.0f; //Use 100% lead modifier

    private Vector3 leadVector; //How far in front of (or otherwise away from) the player to shoot
    public float leadModifier = 1.0f;

    public override void Awake()
    {
        //Load components
        pawn = gameObject.GetComponent<Pawn>();
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        if (player == null)
        {
            FindPlayer();
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        //Only find the player if there is no player in the scene
        if (player == null)
        {
            FindPlayer();
        }
        //Otherwise, follow the player
        else
        {
            SetLeadVector();
            MoveToPlayer();
            RotateTowardsPlayer();

            //As long as there is a weapon equiped, shoot at the player
            if (pawn.weapon != null)
            {
                ShootAtPlayer();
            }
            else
            {

            }
        }
    }

    public void SetLeadVector()
    {
        //Find distance to player
        float distanceToPlayer = Vector3.Distance(player.transform.position, pawn.transform.position);

        //Clamp that distance between our zero lead and max lead distances
        distanceToPlayer = Mathf.Clamp(distanceToPlayer, noLeadDistance, maxLeadDistance);

        //Find how far from the start of your lead range you are
        float dTPFromMin = distanceToPlayer - noLeadDistance;
        float totalLeadDistanceRange = maxLeadDistance - noLeadDistance;

        //Find what percent of the total range I currently am
        float percentOfLeadDistanceRange = dTPFromMin / totalLeadDistanceRange;

        //Now that I have that range, I can multiply my lead modifier by it
        //Find a few "seconds" in front of the player
        leadVector = player.pawn.anim.velocity * (leadModifier * percentOfLeadDistanceRange);
    }

    public void ShootAtPlayer()
    {
        //Find distance to player
        float distanceToPlayer = Vector3.Distance(player.transform.position, pawn.transform.position);

        //As long as you are within shooting distance, shoot at the player
        if (distanceToPlayer > minShootingDistance && distanceToPlayer < maxShootingDistance)
        {
            //Set the error for shooting so that the AI doesn't always hit their target (non-perfect AI)
            float shootingError = Random.Range(-maxShootingError * 0.5f, maxShootingError * 0.5f);

            //Rotate weapon for error
            pawn.weapon.transform.Rotate(0, shootingError, 0);

            //Countdown our timer
            countdown -= Time.deltaTime;
            //If our countdown hits zero--
            if (countdown <= 0)
            {
                //Shoot
                pawn.weapon.Shoot();

                //Reset timer
                countdown = fireDelay;
            }

            

            //Rotate back
            pawn.weapon.transform.Rotate(0, -shootingError, 0);
        }

        
    }

    public void FindPlayer()
    {
        player = FindObjectOfType<PlayerController>();
    }

    public void MoveToPlayer()
    {
        //Set the player as the destination
        agent.SetDestination(player.pawn.transform.position);

        //Find the vector of the path
        Vector3 desiredMovement = agent.desiredVelocity;

        //Set it to local direction (forward/right) not world (north/west) direction
        desiredMovement = pawn.transform.InverseTransformDirection(desiredMovement);

        //Adjust it for our pawn speed
        desiredMovement = desiredMovement.normalized * pawn.moveSpeed;

        //Send to the animator
        pawn.anim.SetFloat("Forward", desiredMovement.z);
        pawn.anim.SetFloat("Right", desiredMovement.x);
    }

    public void RotateTowardsPlayer()
    {
        //Find vector to player
        Vector3 vectorToPlayer = (player.pawn.transform.position + leadVector) - pawn.transform.position;

        //Find Quaternion that is look down that vector
        Quaternion lookRotation = Quaternion.LookRotation(vectorToPlayer, Vector3.up);

        //Rotate a little bit towards that rotation
        pawn.transform.rotation = Quaternion.RotateTowards(pawn.transform.rotation, lookRotation, pawn.rotateSpeed * Time.deltaTime);
    }

    public void OnAnimatorMove()
    {
        //Tell the agent that the animator moved us (so it doesn't have to)
        agent.velocity = pawn.anim.velocity;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
