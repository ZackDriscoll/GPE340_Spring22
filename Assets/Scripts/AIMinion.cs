using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMinion : AIController
{
    private Pawn pawn;
    private NavMeshAgent agent;

    public float maxShootingError = 1.0f;

    private PlayerController player;

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
            MoveToPlayer();

            if (pawn.weapon != null)
            {
                ShootAtPlayer();
            }
        }
    }

    public void ShootAtPlayer()
    {
        //Set the error for shooting so that the AI doesn't always hit their target (non-perfect AI)
        float shootingError = Random.Range(-maxShootingError * 0.5f, maxShootingError * 0.5f);

        //Rotate weapon for error
        pawn.weapon.transform.Rotate(0, shootingError, 0);

        //Shoot
        pawn.weapon.Shoot();

        //Rotate back
        pawn.weapon.transform.Rotate(0, -shootingError, 0);
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

    public void OnAnimatorMove()
    {
        //Tell the agent that the animator moved us (so it doesn't have to)
        agent.velocity = pawn.anim.velocity;
    }
}
